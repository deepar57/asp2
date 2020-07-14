using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
	public interface IProductData
	{
		IEnumerable<Section> GetSections();

		Section GetSection(int Id);

		IEnumerable<Brand> GetBrands();

		Brand GetBrand(int Id);// => GetBrands().FirstOrDefault(b => b.Id == Id);

		PageProductsDto GetProducts(ProductFilter Filter = null);

		ProductDto GetProductById(int id);
	}
}