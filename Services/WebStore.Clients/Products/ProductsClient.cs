﻿using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Dto.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
	public class ProductsClient : BaseClient, IProductData
	{
		public ProductsClient(IConfiguration Configuration) : base(Configuration, WebAPI.Products) { }

		public IEnumerable<Section> GetSections() => Get<IEnumerable<Section>>($"{_ServiceAddress}/sections");

		public Section GetSection(int Id) => Get<Section>($"{_ServiceAddress}/section/{Id}");

		public IEnumerable<Brand> GetBrands() => Get<IEnumerable<Brand>>($"{_ServiceAddress}/brands");

		public Brand GetBrand(int Id) => Get<Brand>($"{_ServiceAddress}/brand/{Id}");

		public PageProductsDto GetProducts(ProductFilter Filter = null) =>
			Post(_ServiceAddress, Filter ?? new ProductFilter())
			   .Content
			   .ReadAsAsync<PageProductsDto>()
			   .Result;

		public ProductDto GetProductById(int id) => Get<ProductDto>($"{_ServiceAddress}/{id}");
	}
}