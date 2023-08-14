using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Kitchen.Core;
using Kitchen.Core.Domain;
using Kitchen.Core.Extension;
using Kitchen.Core.Commons;
using Kitchen.Service.DTOs.CommonsDTO;

namespace shop.Service.Extension
{
    public static class GenericMapping
    {
        public static TDTO ToDTO<TDTO>(this Entity entity)
        {
            if (typeof(TDTO).GetInterface("IDateDTO") != null && entity.GetType().GetInterface("IDateEntity") != null)
            {
                Mapster.TypeAdapterConfig<IDateEntity, TDTO>.NewConfig().Map("LocalCreate", p => p.CreateON.ToPersian())
                    .Map("LocalUpdate", p => p.UpdateON.ToPersian());
            }
            var dto = entity.Adapt<TDTO>();
            return dto;
        }
        public static TEntity ToEntity<TEntity>(this BaseDTO baseDto)
        {
            if (typeof(TEntity).GetInterface("IDateEntity") != null)
            {
                TypeAdapterConfig<BaseDTO, TEntity>.NewConfig().Ignore("CreateOn", "UpdateOn", "LocalCreate", "LocalUpdate");
            }

            var entity = baseDto.Adapt<TEntity>();
            return entity;
        }
    }
}
