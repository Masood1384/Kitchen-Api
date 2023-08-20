using Kitchen.Core.Domain.Order;
using Kitchen.Service.DTOs.CommonsDTO;

namespace Kitchen.Service.DTOs.OrderDTO
{
    public class OrderItemDTO:BaseEntityDTO
    {
        public int OrderTotal { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus orderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }
        public bool Deleted { get; set; }
        public int UserId { get; set; }
    }
}