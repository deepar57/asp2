using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.ViewModels;

namespace WebStore.Domain.Dto.Order
{
	public class CreateOrderModel
	{
		public OrderViewModel Order { get; set; }

		public List<OrderItemDto> Items { get; set; }
	}
}
