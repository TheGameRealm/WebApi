using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security;
using NLog;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Web.Controllers;
using Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Data.Entity;
using Data.Repositories;
using System.Web.Http;
using Core.Providers;

namespace Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<HttpConfiguration>(new InjectionFactory(config => GlobalConfiguration.Configuration));
            
            container.RegisterType<RealmContext>();
            container.RegisterType<ILogger>(new InjectionFactory(logger => LogManager.GetCurrentClassLogger()));
            container.RegisterType<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>();

            container.RegisterType<ISecurityRepository, SecurityRepository>();
            container.RegisterType<IMapRepository, MapRepository>();
            container.RegisterType<IAlexaRepository, AlexaRepository>();

            container.RegisterType<IIntentProvider, IntentProvider>();
            
        }
    }
}
