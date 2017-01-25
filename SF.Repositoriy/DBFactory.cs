//------------------------------------------------------------------------------
// DBFactory.cs
//
// <copyright from='2017' to='2117' company='Smartware Enterprises Inc'> 
// Copyright (c) Smartware Enterprises Inc. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/23/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System.Data.Entity;

using Castle.Windsor;

using SF.Repositoriy.Entities;

namespace SF.Repositoriy
{
    public class DBFactory : IDbFactory
    {
        private readonly IWindsorContainer _container;

        public DBFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public DbContext GetContext()
        {
            return _container.Resolve<SFContext>();
        }
    }
}
