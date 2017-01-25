//------------------------------------------------------------------------------
// ServiceInstaller.cs
//
// <copyright from='2017' to='2117' company='Smartware Enterprises Inc'> 
// Copyright (c) Smartware Enterprises Inc. All Rights Reserved. 
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
using SF.IService;
using SF.Repositoriy;
using SF.Service.UnitOfWork;

namespace SF.Service.Installer
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestylePerWebRequest(),
                Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestylePerWebRequest(),
                Component.For<IDbFactory>().ImplementedBy<DBFactory>().LifestyleSingleton(),
                Component.For<SFContext>().LifestylePerWebRequest(),

                Component.For<IAccountService>().ImplementedBy<AccountService>().LifestyleSingleton()
            );
        }
    }
}
