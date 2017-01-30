//------------------------------------------------------------------------------
// LogicInstaller.cs
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

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using SF.ILogic;

namespace SF.Logic.Installer
{
    public class LogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IClientLogic>().ImplementedBy<ClientLogic>().LifestylePerWebRequest(),
                Component.For<IAccountLogic>().ImplementedBy<AccountLogic>().LifestylePerWebRequest(),
                Component.For<IOrderLogic>().ImplementedBy<OrderLogic>().LifestylePerWebRequest(),
                Component.For<IRoomLogic>().ImplementedBy<RoomLogic>().LifestylePerWebRequest()
                );
        }
    }
}
