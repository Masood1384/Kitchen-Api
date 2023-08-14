using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Kitchen.Core.Domain.Food;

namespace Kitchen.Data.Mapping
{
    public class FoodPictureMapp : IEntityTypeConfiguration<FoodPicture>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FoodPicture> builder)
        {
            builder.HasKey(p => new { p.FoodID , p.PictureID });
        }
    }
}