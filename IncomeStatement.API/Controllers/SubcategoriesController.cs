using IncomeStatement.API.Requests;
using IncomeStatement.Application.Subcategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncomeStatement.API.Controllers
{
    [Route("/api/v1/subcategories")]
    [ApiController]
    public class SubcategoriesController : IncomeControllerBase
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoriesController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpPost("", Name = "CreateSubcategory")]
        public async Task<IActionResult> CreateSubcategory([FromBody] CreateSubcategoryRequest request)
        {
            var result = await _subcategoryService.AddSubcategory(request.Name, request.CategoryId);

            if (result.IsSuccess)
                return NoContent();

            return HandleErrors(result.Errors);
        }

        [HttpDelete("{id}", Name = "DeleteSubcategory")]
        public async Task<IActionResult> DeleteSubcategory(Guid id)
        {
            var result = await _subcategoryService.RemoveSubcategory(id);

            if (result.IsSuccess)
                return NoContent();

            return HandleErrors(result.Errors);
        }
    }
}
