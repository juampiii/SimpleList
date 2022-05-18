using MediatR;

namespace SimpleList.Application.Features.Lists.Commands.DeleteList
{
    public class DeleteListCommand : IRequest<int>
    {
        public int? Id { get; set; }
    }
}
