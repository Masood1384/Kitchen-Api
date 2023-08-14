using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kitchen.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Kitchen.Core.Extension;

namespace Kitchen.Framework.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var list = typeof(IApplicationStartup).GetAllClassTypes();
            List<IApplicationStartup> listObject = new List<IApplicationStartup>();

            foreach (var TypeItem in list)
            {
                var ob = Activator.CreateInstance(TypeItem) as IApplicationStartup;
                listObject.Add(ob);
            }

            foreach (var item in listObject)
            {
                item.ConfigureServices(services,configuration);
            }
        }

    }
}
