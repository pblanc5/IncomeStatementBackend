using DomainResults.Mvc;
using IncomeStatement.API.Requests;
using IncomeStatement.Application.LineItem.Command.AddLineItem;
using IncomeStatement.Application.LineItem.Command.DeleteLineItem;
using IncomeStatement.Application.LineItem.Command.UpdateLineItem;
using IncomeStatement.Application.LineItem.Query.GetLineItemById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncomeStatement.API.Controllers
{
    [Route("/api/v1/lineitems")]
    [ApiController]
    public class LineItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LineItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetStatementLineItemById")]
        public async Task<IActionResult> GetStatementLineItemById(Guid id) 
        {
            var query = new GetLineItemByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);

            if (!result.IsSuccess )
                return result.ToActionResult();
            return Ok(result.Value);
        }

        [HttpPost(Name = "AddStatementLineItem")]
        public async Task<IActionResult> AddStatementLineItem([FromBody] CreateStatementLineItemRequest request)
        {
            var command = new AddLineItemCommand
            {
                StatementId = request.StatementId,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                TypeId = request.LineItemTypeId,
                Description = request.Description,
                Amount = request.Amount,
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return result.ToActionResult();

            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateStatementLineItem")]
        public async Task<IActionResult> UpdateStatementLineItem([FromRoute] Guid id, [FromBody] UpdateStatementLineItemRequest request)
        {
            var command = new UpdateLineItemCommand
            {
                Id = id,
                CategoryId = request.CategoryId,
                SubcategoryId = request.SubcategoryId,
                TypeId = request.LineItemTypeId,
                Description = request.Description,
                Amount = request.Amount,
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return result.ToActionResult();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "RemoveStatementLineItem")]
        public async Task<IActionResult> RemoveStatementLineItem(Guid id)
        {
            var command = new DeleteLineItemCommand
            { 
                Id = id
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return result.ToActionResult();

            return NoContent();
        }
    }
}
