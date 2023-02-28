using IncomeStatement.API.Requests;
using IncomeStatement.Application.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IncomeStatement.API.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name = "ListCategories")]
        public async Task<IActionResult> ListCategories()
        {
            var result = await _categoryService.ListCategories();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return HandleErrors(result.Errors);
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {

            var result = await _categoryService.AddCategory(request.Name);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return HandleErrors(result.Errors);

        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return HandleErrors(result.Errors);
        }

        private ObjectResult HandleErrors(IReadOnlyCollection<string> errors)
        {
            var errorsString = errors.Aggregate((a, b) => a + "; " + b);
            return Problem(errorsString, HttpContext.Request.Path, StatusCodes.Status500InternalServerError);
        }
    }
}
