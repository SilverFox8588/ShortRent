//------------------------------------------------------------------------------
// LinqExtension.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/30/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SF.Logic.Common
{
    /// <summary>
    /// Linq extension.
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return source as IOrderedQueryable<TEntity>;
            }

            MethodCallExpression resultExp = GenerateMethodCall(source, "OrderBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> SortByDescending<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return source as IOrderedQueryable<TEntity>;
            }

            MethodCallExpression resultExp = GenerateMethodCall(source, "OrderByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Thens the by.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> ThenSortBy<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return source;
            }

            MethodCallExpression resultExp = GenerateMethodCall(source, "ThenBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Thens the by descending.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> ThenSortByDescending<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return source;
            }

            MethodCallExpression resultExp = GenerateMethodCall(source, "ThenByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        /// <summary>
        /// Orders the using sort expression.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> SortUsingSortExpression<TEntity>(this IQueryable<TEntity> source, string sortExpression) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(sortExpression))
            {
                return source as IOrderedQueryable<TEntity>;
            }

            String[] orderFields = sortExpression.Split(',');
            IOrderedQueryable<TEntity> result = null;
            for (int currentFieldIndex = 0; currentFieldIndex < orderFields.Length; currentFieldIndex++)
            {
                String[] expressionPart = orderFields[currentFieldIndex].Trim().Split(' ');
                String sortField = expressionPart[0];
                Boolean sortDescending = (expressionPart.Length == 2) && (expressionPart[1].Equals("DESC", StringComparison.OrdinalIgnoreCase));
                if (sortDescending)
                {
                    result = currentFieldIndex == 0 ? source.SortByDescending(sortField) : result.ThenSortByDescending(sortField);
                }
                else
                {
                    result = currentFieldIndex == 0 ? source.SortBy(sortField) : result.ThenSortBy(sortField);
                }
            }
            return result;
        }

        private static LambdaExpression GenerateSelector<TEntity>(String propertyName, out Type resultType) where TEntity : class
        {
            PropertyInfo property;
            Expression propertyAccess;
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "Entity");

            if (propertyName.Contains('.'))
            {
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }

            resultType = property.PropertyType;

            return Expression.Lambda(propertyAccess, parameter);
        }

        private static MethodCallExpression GenerateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, string fieldName) where TEntity : class
        {
            Type type = typeof(TEntity);
            Type selectorResultType;
            LambdaExpression selector = GenerateSelector<TEntity>(fieldName, out selectorResultType);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
            new[] { type, selectorResultType },
            source.Expression, Expression.Quote(selector));
            return resultExp;
        }
    }
}
