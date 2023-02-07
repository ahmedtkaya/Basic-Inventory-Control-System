using System;
using InventoryControl.Models;
using InventoryControl.Services;
using Microsoft.AspNetCore.Mvc;
namespace InventoryControl.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly ProductsService _productsService;
		public ProductsController(ProductsService productsService) =>
			_productsService = productsService;
		

		[HttpGet]
		public async Task<List<Products>> Get() => await _productsService.GetProductAsync();

		[HttpPost]
		public async Task <IActionResult> Post(Products newProduct)
		{
			await _productsService.CreateProductAsync(newProduct);
			

			return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
		}


		[HttpGet("{id:length(24)}")]
		public async Task<ActionResult<Products>> Get(string id)
		{
			var product = await _productsService.GetProductAsync(id);

			if(product is null)
			{
				return NotFound();
			}
			return product;
		}


		
	}
}

