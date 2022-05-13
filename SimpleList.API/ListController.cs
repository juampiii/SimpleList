using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleList.Application.Features.Lists.Commands.CreateList;
using SimpleList.Application.Features.Lists.Queries.GetAllLists;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;
using System.Net;

namespace SimpleList.API
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/{userId:int}", Name = "GetListsByUser")]
        [ProducesResponseType(typeof(IEnumerable<ListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> GetListsByUserId(int userId)
        {
            return Ok(await _mediator.Send(
                new GetListsByUserIdQuery(userId)));
        }

        [HttpPost(Name = "CreateList")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListViewModel>>> CreateList([FromBody] CreateListCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
