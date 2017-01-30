//------------------------------------------------------------------------------
// BaseService.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/23/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System.Data.Entity;
using System.Linq;

using SF.Repositoriy;

namespace SF.Service
{
    public class BaseService<T> where T : class
    {
        private readonly IDbFactory _dbFactory;
        private DbContext DataContext => _dbFactory.GetContext();
        private IDbSet<T> DbSet => DataContext.Set<T>();

        public BaseService(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Create(T model)
        {
            DbSet.Add(model);
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IQueryable<T> Query()
        {
            return DbSet.AsQueryable();
        }
        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Edit(T model)
        {
            DataContext.Entry(model).State = EntityState.Modified;
        }
    }
}
