using MediatR;

namespace SimpleList.Application.Features.Items.Queries.GetItemsByListId
{
    public class GetItemsByListIdQuery : IRequest<List<ItemViewModel>>
    {
        public int? ListId { get; set; }

        public GetItemsByListIdQuery(int? listId)
        {
            ListId = listId ?? throw new ArgumentNullException(nameof(listId));
        }
    }
}
