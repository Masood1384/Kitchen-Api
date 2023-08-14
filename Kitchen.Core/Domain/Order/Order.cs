using Kitchen.Core.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Core.Domain.Order
{
    public class Order : BaseEntity
    {
        public int OrderTotal { get; set; }
        public int OrderStatusId { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int OrderId { get; set; }
        public OrderStatus orderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }
        public bool Deleted { get; set; }
        public int UserId { get; set; }


        //Navigation Properties

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual  Kitchen.Core.Domain.User.User User { get; set; }
    }
}