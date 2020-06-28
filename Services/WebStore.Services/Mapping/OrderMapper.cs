using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.Domain.Dto.Order;
using WebStore.Domain.Entities.Orders;

namespace WebStore.Services.Mapping
{
	public static class OrderMapper
	{
		public static OrderDto ToDto(this Order p) => (p is null) ? null : new OrderDto
		{
			Id = p.Id,
			Name = p.Name,
			Phone = p.Phone,
			Address = p.Address,
			Date = p.Date,
			Items = p.Items.Select(c => c.ToDto())
		};

		public static Order FromDto(this OrderDto p) => (p is null) ? null : new Order
		{
			Id = p.Id,
			Name = p.Name,
			Phone = p.Phone,
			Address = p.Address,
			Date = p.Date,
			Items = p.Items.Select(c => c.FromDto()).ToArray()
		};

		public static OrderItemDto ToDto(this OrderItem p) => (p is null) ? null : new OrderItemDto
		{
			Id = p.Id,
			Price = p.Price,
			Quantity = p.Quantity
		};

		public static OrderItem FromDto(this OrderItemDto p) => (p is null) ? null : new OrderItem
		{
			Id = p.Id,
			Price = p.Price,
			Quantity = p.Quantity
		};
	}
}
