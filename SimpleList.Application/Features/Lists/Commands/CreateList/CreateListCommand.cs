using MediatR;

namespace SimpleList.Application.Features.Lists.Commands.CreateList
{
    public class CreateListCommand : IRequest<int>
    {
        public string? Name { get; set; }
    }
}
