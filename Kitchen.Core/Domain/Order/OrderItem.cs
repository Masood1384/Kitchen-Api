using Kitchen.Core.Commons;

namespace Kitchen.Core.Domain.Order
{
    public class OrderItem : BaseRelation,IDateEntity
    {
        public int Food_Id { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public DateTime CreateON { get; set; }
        public DateTime UpdateON { get; set; }

        //Navigation Properties
        public virtual Kitchen.Core.Domain.Food.Food Food { get; set; }
        public virtual Order Order { get; set; }
    }
}