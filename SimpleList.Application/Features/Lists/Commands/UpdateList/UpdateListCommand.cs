using MediatR;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;

namespace SimpleList.Application.Features.Lists.Commands.EditList
{
    public class UpdateListCommand : IRequest<ListViewModel>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
