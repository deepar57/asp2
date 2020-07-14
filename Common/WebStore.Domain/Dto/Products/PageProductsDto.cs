using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Dto.Products
{
	public class PageProductsDto
	{
		public IEnumerable<ProductDto> Products { get; set; }

		public int TotalCount { get; set; }
	}
}