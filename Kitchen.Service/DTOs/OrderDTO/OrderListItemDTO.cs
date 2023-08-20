using Kitchen.Core.Domain.Order;
using Kitchen.Service.DTOs.CommonsDTO;

namespace Kitchen.Service.DTOs.OrderDTO
{
    public class OrderListItemDTO:BaseItemDTO
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
        public string UserName { get; set; }
        public string UserFamily { get; set; }
    }
}