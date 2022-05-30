using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleList.Application.Features.Items.Commands.CreateItem;
using SimpleList.Application.Features.Items.Queries.GetItemsByListId;
using System.Net;

namespace SimpleList.API.Controllers
{
    [ApiController]
    [Route("api/v1/Lists/{listId:int}/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetItemsByListId")]
        [ProducesResponseType(typeof(IEnumerable<ItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ItemViewModel>>> GetItemsByListId(int listId)
        {
            return Ok(await _mediator
                .Send(new GetItemsByListIdQuery(listId)));
        }

    [HttpPost(Name = "CreateItem")]
    public async Task<ActionResult<ItemViewModel>> CreateItem([FromRoute] int listId, 
        [FromBody] CreateItemCommand request)
    {
        request.ListId = listId;
        return Ok(await _mediator.Send(request));
    }
    }
}
