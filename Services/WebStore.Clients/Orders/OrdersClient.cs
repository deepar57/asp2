using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Dto.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Orders
{
	public class OrdersClient : BaseClient, IOrderService
	{
		public OrdersClient(IConfiguration Configuration)
				: base(Configuration, WebAPI.Orders)
		{
		}

		public async Task<OrderDto> CreateOrder(string UserName, CreateOrderModel OrderModel)
		{
			var response = await PostAsync($"{_ServiceAddress}/{UserName}", OrderModel);
			return await response.Content.ReadAsAsync<OrderDto>();
		}

		public async Task<IEnumerable<OrderDto>> GetUserOrders(string UserName)
		{
			return await GetAsync<IEnumerable<OrderDto>>($"{_ServiceAddress}/user/{UserName}");
		}

		public async Task<OrderDto> GetOrderById(int id)
		{
			return await GetAsync<OrderDto>($"{_ServiceAddress}/{id}");
		}
	}
}
