using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
	[Route(WebAPI.Products)]
	[ApiController]
	public class ProductsApiController : ControllerBase, IProductData
	{
		private readonly IProductData _IProductData;

		public ProductsApiController(IProductData productData)
		{
			_IProductData = productData;
		}

		[HttpGet("brands")] // api/products/brands
		public IEnumerable<Brand> GetBrands()
		{
			return _IProductData.GetBrands();
		}

		[HttpGet("sections")]
		public IEnumerable<Section> GetSections()
		{
			return _IProductData.GetSections();
		}

		[HttpPost]
		public IEnumerable<ProductDto> GetProducts([FromBody] ProductFilter Filter = null)
		{
			return _IProductData.GetProducts(Filter);
		}

		[HttpGet("{id}")]
		public ProductDto GetProductById(int id)
		{
			return _IProductData.GetProductById(id);
		}
	}
}
