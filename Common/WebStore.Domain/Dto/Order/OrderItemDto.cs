﻿using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Dto.Order
{
	public class OrderItemDto : IBaseEntity
	{
		public int Id { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }
	}
}
