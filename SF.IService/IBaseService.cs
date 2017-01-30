//------------------------------------------------------------------------------
// IBaseService.cs
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

using System.Linq;

namespace SF.IService
{
    public interface IBaseService<T> where T : class
    {
        void Create(T model);

        void Delete(int id);

        void Edit(T model);

        IQueryable<T> Query();

        T Get(int id);
    }
}
