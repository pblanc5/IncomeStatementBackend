using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement.Enums;
using Microsoft.AspNetCore.Mvc;

namespace IncomeStatement.API.Controllers
{
    [Route("/api/v1/types")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListTypes()
        {
            var types = Enumeration.GetAll<LineItemTypes>();
            return Ok(types);
        }
    }
}
