using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;

namespace WebStore.Services.Mapping
{
	public static class SectionMapper
	{
		public static SectionDto ToDto(this Section p) => (p is null) ? null : new SectionDto
		{
			Id = p.Id,
			Name = p.Name
		};

		public static Section FromDto(this SectionDto p) => (p is null) ? null : new Section
		{
			Id = p.Id,
			Name = p.Name
		};
	}
}
