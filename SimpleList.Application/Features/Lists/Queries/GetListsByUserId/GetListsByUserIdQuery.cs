using MediatR;
using SimpleList.Application.Features.Lists.Queries.GetListsByUserId;

namespace SimpleList.Application.Features.Lists.Queries.GetAllLists
{
    public class GetListsByUserIdQuery : IRequest<List<ListViewModel>>
    {
        public int UserId { get; set; }
        public GetListsByUserIdQuery(int? userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}
