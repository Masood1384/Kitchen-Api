using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kitchen.Core.Infrastructure;

namespace Kitchen.Framework.Infrastructure
{
    public class ControllerStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            IMvcBuilder config = services.AddControllers();
            config.ConfigureApiBehaviorOptions((options) =>
            {
                
                options.ClientErrorMapping[500].Title = "درخواست نامعتبر";
                options.ClientErrorMapping[403].Title = "منبع مورد نظر یافت نشد";
                options.InvalidModelStateResponseFactory = (Context) =>
                {
                    var values = Context.ModelState.Values.Where(state => state.Errors.Count != 0)
                        .Select(state => state.Errors.Select(p => new { errorMessage = p.ErrorMessage }));

                    return new BadRequestObjectResult(values);

                };
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseRouting();
            //app.UseEndpoints(endpoint =>
            //{
            //    endpoint.MapControllers();
            //});

            

        }

       
    }
}
