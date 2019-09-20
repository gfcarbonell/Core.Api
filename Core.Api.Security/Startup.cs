using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Api.CrossCutting.Registers;
using Core.Api.DataAccess.Contract.IDbContexts;
using Core.Api.DataAccess.DbContexts.Security;
using Core.Api.Security.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Core.Api.Security
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
            // Data Contexts 
            services.AddScoped<ISecurityDbContext, SecurityDbContext>();
            services.AddDbContext<SecurityDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("CoreSecurityDB")));

            // MVC Version
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add Sessions 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Injection Dependences
            IoCRegister.AddRegistration(services);

            // Swagger
            SwaggerConfig.AddRegistration(services);
                        
            // Enable Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable Cors
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Swagger
            SwaggerConfig.AddRegistration(app);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
