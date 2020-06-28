using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;

namespace WebStore.Services.Mapping
{
	public static class ProductMapper
	{
		public static ProductViewModel ToView(this Product p) => new ProductViewModel
		{
			Id = p.Id,
			Name = p.Name,
			Order = p.Order,
			Price = p.Price,
			ImageUrl = p.ImageUrl,
			Brand = p.Brand?.Name,
		};

		public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);

		public static ProductDto ToDto(this Product p) => (p is null) ? null : new ProductDto
		{
			Id = p.Id,
			Name = p.Name,
			Order = p.Order,
			Price = p.Price,
			ImageUrl = p.ImageUrl,
			Brand = p.Brand.ToDto(),
			Section = p.Section.ToDto()
		};

		public static Product FromDto(this ProductDto p) => (p is null) ? null : new Product
		{
			Id = p.Id,
			Name = p.Name,
			Order = p.Order,
			Price = p.Price,
			ImageUrl = p.ImageUrl,
			Brand = p.Brand.FromDto(),
			Section = p.Section.FromDto()
		};
	}
}
