using System;
using InventoryControl.Models;
using InventoryControl.Services;
using Microsoft.AspNetCore.Mvc;
namespace InventoryControl.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService) =>
            _categoryService = categoryService;


        [HttpGet]
        public async Task<List<Category>> Get() => await _categoryService.GetCategoryAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Category newCategory)
        {
            await _categoryService.CreateCategoryAsync(newCategory);


            return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
        }
    }
}

