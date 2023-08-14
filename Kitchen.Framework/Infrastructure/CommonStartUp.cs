using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kitchen.Core.Infrastructure;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Kitchen.Service.Middleware;

namespace Kitchen.Framework.Infrastructure
{
    public class CommonStartUp:IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            IWebHostEnvironment env = app.ApplicationServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>

                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kitchen API V1")
                    );

            }

            app.UseExceptionHandler(app =>
            {
                //Register Exception Middleware
                app.UseMiddleware<ErrorHandlerMiddleware>();
            });

            app.UseMiddleware<MapsterConfigMiddleWare>();


        }

        
    }
}
