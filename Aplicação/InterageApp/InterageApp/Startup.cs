using InterageApp.Authentication;
using InterageApp.DTO;
using InterageApp.Mapping.Implementations;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using InterageApp.Repository.Implementations;
using InterageApp.Repository.Interfaces;
using InterageApp.Services.Implementations;
using InterageApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace InterageApp
{
    public class Startup
    {
        private SymmetricSecurityKey _signingKey;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region MVC Configurations
            services.AddOptions();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            #endregion

            #region Authorization
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("JwtIssuerOptions").GetSection("SecretKey").Value));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = Configuration.GetSection("JwtIssuerOptions").GetSection("Issuer").Value;
                options.Audience = Configuration.GetSection("JwtIssuerOptions").GetSection("Audience").Value;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("JwtIssuerOptions").GetSection("Issuer").Value,

                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("JwtIssuerOptions").GetSection("Audience").Value,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });
            #endregion

            #region Policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DisneyUser", policy => policy.RequireClaim("DisneyCharacter", "IAmMickey"));
            });
            #endregion

            #region Dependency Injection

            #region DbContext
            services.AddSingleton<DbContext, InterageContext>();
            #endregion

            #region MappingServices
            services.AddSingleton<IGenericMappingService<UsuarioDTO,Usuario>, UsuarioMappingService>();
            services.AddSingleton<IGenericMappingService<PerfilDTO, Perfil>, PerfilMappingService>();
            services.AddSingleton<IGenericMappingService<CredenciaisDTO, Credenciais>, CredenciaisMappingService>();
            services.AddSingleton<IEnderecoUsuarioMappingService, EnderecoUsuarioMappingService>();
            #endregion

            #region RepositoryService
            services.AddSingleton(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddSingleton<ICredenciaisRepository, CredenciaisRepository>();
            services.AddSingleton<IUsuariosRepository, UsuarioRepository>();
            #endregion

            #region Services
            services.AddSingleton<IUsuariosService, UsuariosService>();
            #endregion

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
