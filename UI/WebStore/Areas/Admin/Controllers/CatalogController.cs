﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebStore.Areas.Admin.Controllers
{
	[Area("Admin"), Authorize(Roles = Role.Administrator)]
	public class CatalogController : Controller
	{
		private readonly IProductData _ProductData;

		public CatalogController(IProductData ProductData) => _ProductData = ProductData;

		public IActionResult Index() => View(_ProductData.GetProducts().Select(c => c.FromDto()));

		public IActionResult Edit(int? id)
		{
			var product = id is null ? new Product() : _ProductData.GetProductById((int)id).FromDto();

			if (product is null)
				return NotFound();

			return View(product);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Edit(Product product) => RedirectToAction(nameof(Index));

		public IActionResult Delete(int id)
		{
			var product = _ProductData.GetProductById(id).FromDto();

			if (product is null)
				return NotFound();

			return View(product);
		}

		[HttpPost, ValidateAntiForgeryToken, ActionName(nameof(Delete))]
		public IActionResult DeleteConfirm(int id) => RedirectToAction(nameof(Index));
	}
}
