using EventHubAPI.Models;
using EventHubAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        
        public IActionResult  Get()
        {
            return new OkObjectResult(_categoryRepository.GetAllCategories());
        }



        // GET api/categories/2
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int Id)
        {
            return new OkObjectResult(_categoryRepository.GetCategoryById(Id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult CreateNewCategory(Category category)
        {
            using (var scope = new TransactionScope())
            {
                _categoryRepository.CreateNewCategory(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new {Id = category.Id});
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            if (category != null)
            {
                using (var scope = new TransactionScope())
                {
                    _categoryRepository.UpdateCategory(category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCateogry(int Id) 
        {
            _categoryRepository.DeleteCategoryById(Id);
            return new OkResult();
        }
    }
}
