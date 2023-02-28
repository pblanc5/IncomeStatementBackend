using IncomeStatement.API.Requests;
using IncomeStatement.Application.Statements.Command.CreateStatement;
using IncomeStatement.Application.Statements.Command.DeleteStatement;
using IncomeStatement.Application.Statements.Command.UpdateStatement;
using IncomeStatement.Application.Statements.Query.GetStatement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncomeStatement.API.Controllers
{
    [Route("api/v1/statements")]
    [ApiController]
    public class StatementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "ListStatements")]
        public async Task<IActionResult> ListStatements([FromQuery] ListStatementsRequest request)
        {
            var query = new GetStatementQuery
            {
                Year = request.Year,
                Month = request.Month,
            };

            var statements = await _mediator.Send(query);

            return Ok(statements);
        }

        [HttpGet("{id}", Name = "GetStatement")]
        public async Task<IActionResult> GetStatement(Guid id)
        {
            return Ok();
        }

        [HttpPost(Name = "CreateStatement")]
        public async Task<IActionResult> CreateStatement([FromBody] CreateStatementRequest request)
        {
            var command = new CreateStatementCommand
            {
                Year = request.Year,
                Month = request.Month,
            };

            var rows = await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateStatement")]
        public async Task<IActionResult> UpdateStatement([FromRoute] Guid id, [FromBody] UpdateStatementRequest request)
        {
            var command = new UpdateStatementCommand
            {
                Id = id,
                Year = request.Year,
                Month = request.Month,
            };

            var rows = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStatement")]
        public async Task<IActionResult> DeleteStatement(Guid id)
        {
            var command = new DeleteStatementCommand
            {
                Id = id
            };

            var rows = await _mediator.Send(command);
            return NoContent();
        }
    }
}
