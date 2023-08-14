using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kitchen.Core.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Kitchen.Core.Domain.User;

namespace Kitchen.Framework.Infrastructure
{
    public class SecurityStartup : IApplicationStartup
    {
        
        public MiddleWarePriority Priority => MiddleWarePriority.High;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //Jwt Service Configure
            
        }

            public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });


        }

    }
}
