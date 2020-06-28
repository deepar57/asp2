using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;

namespace WebStore.Services.Mapping
{
	public static class BrandMapper
	{
		public static BrandDto ToDto(this Brand p) => (p is null) ? null : new BrandDto
		{
			Id = p.Id,
			Name = p.Name
		};

		public static Brand FromDto(this BrandDto p) => (p is null) ? null : new Brand
		{
			Id = p.Id,
			Name = p.Name
		};
	}
}
