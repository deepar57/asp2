using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Dto.Order;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
	[Route(WebAPI.Orders)]
	[ApiController]
	public class OrdersApiController : ControllerBase, IOrderService
	{
		private readonly IOrderService _OrderService;

		public OrdersApiController(IOrderService orderService)
		{
			_OrderService = orderService;
		}

		[HttpPost("{UserName}")]
		public Task<OrderDto> CreateOrder(string UserName, [FromBody] CreateOrderModel OrderModel)
		{
			return _OrderService.CreateOrder(UserName, OrderModel);
		}

		[HttpGet("user/{UserName}")]
		public Task<IEnumerable<OrderDto>> GetUserOrders(string UserName)
		{
			return _OrderService.GetUserOrders(UserName);
		}

		[HttpGet("{id}")]
		public Task<OrderDto> GetOrderById(int id)
		{
			return _OrderService.GetOrderById(id);
		}
	}
}
