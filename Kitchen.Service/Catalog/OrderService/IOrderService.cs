using Kitchen.Service.DTOs.OrderDTO;

namespace Kitchen.Service.Catalog.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderListItemDTO>> GetAllOrders();
        Task<OrderItemDTO> GetOrderById(int id);
        Task<OrderItemDTO> AddOrder(OrderItemDTO Order);
        Task RemoveOrder(int Id);
        Task<OrderItemDTO> UpdateOrder(OrderItemDTO Order);
        bool IsExistOrder(int Id);
        

    }
}