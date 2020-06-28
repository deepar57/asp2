using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
	public class ProductsClient : BaseClient, IProductData
	{
		public ProductsClient(IConfiguration Configuration)
				: base(Configuration, WebAPI.Products)
		{
		}

		public IEnumerable<Section> GetSections()
		{
			return Get<IEnumerable<Section>>($"{_ServiceAddress}/sections");
		}

		public IEnumerable<Brand> GetBrands()
		{
			return Get<IEnumerable<Brand>>($"{_ServiceAddress}/brands");
		}

		public IEnumerable<ProductDto> GetProducts(ProductFilter Filter = null)
		{
			return Post(_ServiceAddress, Filter ?? new ProductFilter())
			.Content
			.ReadAsAsync<IEnumerable<ProductDto>>()
			.Result;
		}

		public ProductDto GetProductById(int id)
		{
			return Get<ProductDto>($"{_ServiceAddress}/{id}");
		}
	}
}
