using Kitchen.Core.Commons;

namespace Kitchen.Core.Domain.Food
{
    public class GroupFood:BaseRelation
    {
        public int GroupID { get; set; }
        public int FoodID { get; set; }

        //*Navigation Properties
        public virtual Food Food { get; set; }
        public virtual Group Group { get; set; }
    }
}