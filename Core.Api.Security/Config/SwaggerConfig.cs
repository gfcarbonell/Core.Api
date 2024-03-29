﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Security.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var basepath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basepath, "Core.Api.Security.xml");

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info // Camel Case
                {
                    Version = "v1",
                    Title = "Api Rest",
                    Description = "Services By: Gian Franco Carbonell | Carlos Carbonell",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "X-Dev",
                        Email = "admin@xdev.pe",
                        Url = "http://www.xdev.pe"
                    }
                });

                c.DescribeAllEnumsAsStrings();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Rest v1"); // Camel Case
            });

            return app;
        }
    }
}
