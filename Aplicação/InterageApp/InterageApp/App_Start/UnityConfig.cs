using InterageApp.DTO;
using InterageApp.Mapping;
using InterageApp.Mapping.Implementations;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using InterageApp.Repository;
using InterageApp.Repository.Implementations;
using InterageApp.Repository.Interfaces;
using InterageApp.Services.Implementations;
using InterageApp.Services.Interfaces;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Web.Http;
using Unity;
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

            container.RegisterType<DbContext, Modelo>();
            container.RegisterType<ISingleMapper<AreaInteresse, AreaInteresseDto>, AreaInteresseMapper>();
            container.RegisterType<ISingleMapper<Perfil, PerfilDto>, PerfilMapper>();
            container.RegisterType<ISingleMapper<Usuario, UsuarioDto>, UsuarioMapper>();
            container.RegisterType<ISingleMapper<Usuario, UsuarioCredenciaisDto>, UsuarioCredenciaisMapper>();
            container.RegisterType<ISingleMapper<Endereco, EnderecoDto>, EnderecoMapper>();
            container.RegisterType<ISingleMapper<Evento, EventoDto>, EventoMapper>();
            container.RegisterType<ISingleMapper<Feedback, FeedbackDto>, FeedbackMapper>();
            container.RegisterType<ISingleMapper<Atividade, AtividadeDto>, AtividadeMapper>();
            container.RegisterType<ISingleMapper<Interacao, InteracaoDto>, InteracaoMapper>();
            container.RegisterType<ISingleMapper<Evento, EventoDto>, EventoMapper>();
            container.RegisterType(typeof(IMapper<,>), typeof(Mapper<,>));


            container.RegisterType<IAtividadesService, AtividadesService>();
            container.RegisterType<IEventosService, EventosService>();
            container.RegisterType<IUsuariosService, UsuariosService>();
            container.RegisterType<IValidateUserService, ValidateUserService>();
            container.RegisterType<IAreasInteresseService, AreasInteresseService>();
            container.RegisterType<IFeedbacksService, FeedbacksService>();
            container.RegisterType<IInteracaoService, InteracaoService>();
            container.RegisterType<IEmailService, EmailService>();


            container.RegisterType(typeof(IGenericRepository<,,>), typeof(GenericRepository<,,>));
            container.RegisterType<IAuthValidateRepository, AuthValidateRepository>();
            container.RegisterType<IInscricoesEventosRepository, InscricoesEventosRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}