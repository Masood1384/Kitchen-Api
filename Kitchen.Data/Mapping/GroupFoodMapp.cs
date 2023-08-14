using Kitchen.Core.Domain.Food;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Data.Mapping
{
    public class GroupFoodMapp : IEntityTypeConfiguration<GroupFood>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GroupFood> builder)
        {
            builder.HasKey(p=> new {p.GroupID, p.FoodID});
        }
    }
}