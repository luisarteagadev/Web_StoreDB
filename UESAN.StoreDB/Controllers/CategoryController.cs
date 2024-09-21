using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;
using UESAN.StoreDB.DOMAIN.Infrastrcture.Data;

namespace UESAN.StoreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCategories(){
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.getCategoryById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category category)
        {
           int categoryId= await _categoryRepository.Insert(category);
            return Ok(categoryId);
            //Para ser más fino usamos Created() averiguar mas sobre esto
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Category category)
        {
            // es más comodo usar var, porque cuando se recibe en automatico, lo pasa a ese tipo de dato
            if(id!=category.Id) return BadRequest();
            var result=await _categoryRepository.Update(category);
            if(!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _categoryRepository.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }

    }
}
