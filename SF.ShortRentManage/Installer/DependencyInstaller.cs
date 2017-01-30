//------------------------------------------------------------------------------
// DependencyInstaller.cs
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

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SF.Logic.Installer;
using SF.Service.Installer;
using System.Web.Http;
using System.Web.Mvc;

namespace SF.ShortRentManage.Installer
{
    public class DependencyInstaller
    {
        private static IWindsorContainer _container;

        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Install(
                FromAssembly.This(),
                FromAssembly.Containing<ServiceInstaller>(),
                FromAssembly.Containing<LogicInstaller>()
                );

            _container.Register(Component.For<IWindsorContainer>().Instance(_container).LifestyleSingleton());
        }

        public static IWindsorContainer Container
        {
            get
            {
                return _container;
            }
        }
    }

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<Controller>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
        }
    }
}