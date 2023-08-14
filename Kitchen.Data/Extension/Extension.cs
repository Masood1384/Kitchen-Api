using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Core.Commons;
using Kitchen.Core.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;



namespace SaIran.Data.Extension
{
    public static class Extension
    {
        public static void CreateON(this ModelBuilder modelBuilder)
        {
            var ListIDateEntities = typeof(IDateEntity).GetAllClassName();

            var ListEntitiesMap = modelBuilder.Model.GetEntityTypes().Where(p => ListIDateEntities.Contains(p.ClrType.FullName));

            foreach (var EntityMap in ListEntitiesMap)
            {

                var props = EntityMap.FindProperty("CreateON");
                if (props != null)
                {
                    props.ValueGenerated = ValueGenerated.OnAdd;
                    
                    props.SetDefaultValue(DateTime.Now);
                }
            }
        }



    }
}
