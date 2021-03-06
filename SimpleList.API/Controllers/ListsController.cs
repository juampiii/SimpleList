using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleList.Application.Features.Lists.Commands.CreateList;
using SimpleList.Application.Features.Lists.Commands.DeleteList;
using SimpleList.Application.Features.Lists.Commands.EditList;
using SimpleList.Application.Features.Lists.Queries.GetAllLists;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;
using System.Net;

namespace SimpleList.API
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[Controller]")]
    public class ListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateList")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> CreateList([FromBody] CreateListCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut(Name = "UpdateList")]
        [ProducesResponseType(typeof(ListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> EditList([FromBody] UpdateListCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{id:int}", Name = "DeleteList")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(ListViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> DeleteList([FromRoute] DeleteListCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("user/{userId:int}", Name = "GetListsByUser")]
        [ProducesResponseType(typeof(IEnumerable<ListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> GetListsByUserId(int userId)
        {
            return Ok(await _mediator.Send(
                new GetListsByUserIdQuery(userId)));
        }
    }
}
