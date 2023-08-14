using Microsoft.EntityFrameworkCore;
using Kitchen.Core.Domain.Food;

namespace Kitchen.Data.Mapping
{
    public class GroupMapp : IEntityTypeConfiguration<Group>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Group> builder)
        {
            
        }
    }
}