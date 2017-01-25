//------------------------------------------------------------------------------
// Global.asax
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

using Castle.Windsor;
using SF.ShortRentManage.Installer;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SF.ShortRentManage
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //private readonly IWindsorContainer container;

        public WebApiApplication()
        {
            //this.container = new WindsorContainer().Install(new DependencyConventions());
            DependencyInstaller.Initialize();
        }

        public override void Dispose()
        {
            DependencyInstaller.Container.Dispose();
            base.Dispose();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorActivator(DependencyInstaller.Container));

            var controllerFactory = new WindsorControllerFactory(DependencyInstaller.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
