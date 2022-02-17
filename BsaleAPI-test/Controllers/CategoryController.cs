using BsaleAPI_test.Data;
using BsaleAPI_test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsaleAPI_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryRepository.GetAllCategories());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCategories(int id)
        {
            return Ok(await _categoryRepository.GetCategoryDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _categoryRepository.InsertCategory(category);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _categoryRepository.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return NoContent();
        }
    }
}
