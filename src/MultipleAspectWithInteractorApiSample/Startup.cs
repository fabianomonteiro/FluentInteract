using FluentInteract;
using LoggingAspectWithProxyApiSample.Aspects;
using LoggingAspectWithProxyApiSample.Repositories;
using LoggingAspectWithProxyApiSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MultipleAspectWithInteractorApiSample.Aspects;
using MultipleAspectWithInteractorApiSample.Commands;
using MultipleAspectWithInteractorApiSample.Queries;
using MultipleAspectWithInteractorApiSample.UseCases;
using System;

namespace LoggingAspectWithProxyApiSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Aspect-oriented programming API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Fabiano Monteiro",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/fabianomonteiro"),
                    },
                });
            });

            // Singleton Without Dependency Injection
            //AspectWeaver.Singleton = new AspectWeaver(
            //    new AuthorizingAspect(),
            //    new CachingAspect(),
            //    new CanExecutingAspect(),
            //    new ChangingExecuteAspect(),
            //    new LoggingAspect(),
            //    new ValidatingAspect());

            services.AddSingleton<IAspectWeaver, AspectWeaver>((serviceProvider) =>
            {
                var aspectWeaver = new AspectWeaver();

                aspectWeaver.AddAspect<AuthorizingAspect>();
                aspectWeaver.AddAspect<CachingAspect>();
                aspectWeaver.AddAspect<CanExecutingAspect>();
                aspectWeaver.AddAspect<ChangingExecuteAspect>();
                aspectWeaver.AddAspect<LoggingAspect>();
                aspectWeaver.AddAspect<ValidatingAspect>();

                return aspectWeaver;
            });

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IDisableAccountUseCase, DisableAccountUseCase>();
            services.AddScoped<IUpdateAccountCommand, UpdateAccountCommand>();
            services.AddScoped<IGetAccountQuery, GetAccountQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aspect-oriented programming API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
