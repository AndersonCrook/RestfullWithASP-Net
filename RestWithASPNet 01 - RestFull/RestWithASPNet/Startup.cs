using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithASPNet.Model.Context;
using RestWithASPNet.Service.Implementattions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using RestWithASPNet.Repository.Generic;
using RestWithASPNet.Services.Implementattions;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using RestWithASPNet.HyperMedia;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;

namespace RestWithASPNet
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            this._configuration = configuration;
            _environment = environment;
            _logger = logger;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception ex) {
                    _logger.LogCritical("Database migration failed", ex);
                    throw;
                }
            }
            services.AddMvc(options => 
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            }).AddXmlSerializerFormatters();

            
            var filterOptionsPerson = new HyperMediaFilterOptions();
            filterOptionsPerson.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptionsPerson);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "RESTfull API with ASP .Net Core",
                    Version = "v1"
                });
            });

            //versionamento boas praticas Microsoft Anderson
            services.AddApiVersioning();

            //Dependency injection Anderson
            services.AddScoped<IPersonService, PersonServiceImpl>();
            services.AddScoped<IBookService, BookServiceImpl>();

          //  services.AddScoped<IPersonRepository, PersonRepositoryImpl>();

            //Dependency Injection of GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepositoryImpl<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"DefaultApi",
                    template: "{Controller=Values}/{Id?}");
            });
        }
    }
}
