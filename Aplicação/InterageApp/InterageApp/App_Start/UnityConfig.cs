using InterageApp.DTO;
using InterageApp.Mapping;
using InterageApp.Models;
using InterageApp.Repository;
using InterageApp.Services;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;

namespace InterageApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbContext, Contexto>();
            container.RegisterType(typeof(IRepository<,,>), typeof(Repository<,,>));
            container.RegisterType(typeof(IService<,,>), typeof(Service<,,>));
            container.RegisterType<IMapper<Perfil, PerfilDto>, PerfilMapper>();
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<ICryptoService, CryptoService>();
            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}