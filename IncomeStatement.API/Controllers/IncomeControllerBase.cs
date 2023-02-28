using Microsoft.AspNetCore.Mvc;

namespace IncomeStatement.API.Controllers
{
    public class IncomeControllerBase : ControllerBase
    {
        protected ObjectResult HandleErrors(IReadOnlyCollection<string> errors)
        {
            var errorsString = errors.Aggregate((a, b) => a + "; " + b);
            return Problem(errorsString, HttpContext.Request.Path, StatusCodes.Status500InternalServerError);
        }
    }
}
