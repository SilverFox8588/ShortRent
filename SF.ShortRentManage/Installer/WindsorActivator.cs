//------------------------------------------------------------------------------
// WindsorActivator.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/24/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using Castle.Windsor;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace SF.ShortRentManage.Installer
{
    public class WindsorActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;
        public WindsorActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)_container.Resolve(controllerType);

            request.RegisterForDispose(new Release(() =>
            {
                _container.Release(controller);
            }));

            return controller;
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var controller = (IController)_container.Resolve(controllerType);
            return controller;

        }

        private class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}