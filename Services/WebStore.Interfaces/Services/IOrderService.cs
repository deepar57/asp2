using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain.Dto.Order;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels;

namespace WebStore.Interfaces.Services
{
	public interface IOrderService
	{
		Task<OrderDto> CreateOrder(string UserName, CreateOrderModel OrderModel);

		Task<IEnumerable<OrderDto>> GetUserOrders(string UserName);

		Task<OrderDto> GetOrderById(int id);
	}
}
