using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kitchen.Core.Infrastructure;
using Kitchen.Service.Catalog.FoodService;
using Kitchen.Service.Catalog.GroupService;
using Kitchen.Service.Catalog.PictureService;
using Kitchen.Service.Catalog.UserService;
using Kitchen.Service.Tools.Emailsender;

namespace Kitchen.Service.Infrastructure
{
    public class CommonStratup:IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //Rigester services
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            
        }

       
    }
}
