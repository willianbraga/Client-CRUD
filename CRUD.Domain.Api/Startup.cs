using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CRUD.Domain.Handlers.Contracts;
using CRUD.Domain.Infra.Contexts;
using CRUD.Domain.Infra.Repositories;
using CRUD.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CRUD.Domain.Api
{
    public class Startup
    {
        private const string SWAGGERFILE_PATH = "./swagger/v1/swagger.json";
        private const string API_VERSION = "v1";
        private const string SETTINGS_SECTION = "Settings";
        private const string API_CHECK_KEY = "API";
        private const string PROJECT_NAME = "API CRUD";
        private const string XML_EXTENSION = ".xml";
        private const string SECURITY_TYPE = "Bearer";
        private const string SECURITY_NAME = "Authorization";
        private const string SECURITY_DESCRIPTION = "Authorization Key header using the scheme. Example: \"Bearer {token}\"";
        private const string SECURITY_SCHEME = "oauth2";
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            //services.AddDbContext<DataContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("connectionString")));
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ClientHandler, ClientHandler>();

            AddSwagger(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
               .UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint(SWAGGERFILE_PATH, PROJECT_NAME + API_VERSION);
                });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new OpenApiInfo { Title = PROJECT_NAME, Version = API_VERSION });
                c.AddSecurityDefinition(SECURITY_TYPE, new OpenApiSecurityScheme
                {
                    Description = SECURITY_DESCRIPTION,
                    In = ParameterLocation.Header,
                    Name = SECURITY_NAME,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SECURITY_TYPE
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = SECURITY_TYPE
                            },
                            Scheme = SECURITY_SCHEME,
                            Name = SECURITY_TYPE,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
