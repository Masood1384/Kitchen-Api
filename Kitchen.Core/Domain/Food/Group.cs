using Kitchen.Core.Commons;

namespace Kitchen.Core.Domain.Food
{
    public class Group:BaseEntity
    {
        public string Title { get; set; }
        
        //*Navigation Properties
        public virtual ICollection<GroupFood> GroupFoods { get; set; }

    }
}