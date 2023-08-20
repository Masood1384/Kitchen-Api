using Kitchen.Core.Domain.Order;
using Kitchen.Core.Domain.User;
using Kitchen.Data.Repository;
using Kitchen.Service.DTOs.OrderDTO;
using Microsoft.AspNetCore.Razor.Language;
using shop.Service.Extension;


namespace Kitchen.Service.Catalog.OrderService
{
    public class OrderService : IOrderService
    {
        #region Field
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }
        #endregion
        public async Task<IEnumerable<OrderListItemDTO>> GetAllOrders()
        {
            var lis = _repository.GetAllAsNotraking.Where(p=>p.Deleted==false).Select(p=>new OrderListItemDTO{
                ID = p.ID,
                OrderTotal = p.OrderTotal,
                Adress = p.Adress,
                Phone = p.Phone,
                OrderStatusId = p.OrderStatusId,
                UserName = p.User.Name,
                UserFamily = p.User.Family,
                CreateON = p.CreateON,
                UpdateON = p.UpdateON,
            });
            return lis;
        }

        public async Task<OrderItemDTO> AddOrder(OrderItemDTO Order)
        {
            var enorder = Order.ToEntity<Order>();
            await _repository.Add(enorder);
            return Order;
        }

        public async Task<OrderItemDTO> GetOrderById(int id)
        {
            var order = _repository.GetbyIdAznotraking(id);
            var orderdto = order.ToDTO<OrderItemDTO>();
            return orderdto;
        }

        public async Task RemoveOrder(int Id)
        {
            var order = await _repository.GetbyId(Id);
            await _repository.Delete(order);
        }
        public async Task<OrderItemDTO> UpdateOrder(OrderItemDTO OrderDTO)
        {
            var order =await _repository.GetbyId(OrderDTO.ID);
            order.OrderTotal =  OrderDTO.OrderTotal;
            order.Phone = OrderDTO.Phone;
            order.Adress = OrderDTO.Adress;
            order.orderStatus = OrderStatus.Processing;
            order.UserId = OrderDTO.UserId;
            order.Deleted = true;
            order.CreateON = DateTime.Now;
            order.UpdateON = DateTime.Now;
            var resualte = order.ToDTO<OrderItemDTO>();
            return resualte;

        }
        public bool IsExistOrder(int Id)
        {
            var prod = _repository.GetbyIdAznotraking(Id);
            if (prod == null) return false;
            return true;
        }
    }
}