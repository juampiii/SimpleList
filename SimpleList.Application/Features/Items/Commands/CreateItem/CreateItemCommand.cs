using MediatR;
using SimpleList.Application.Features.Items.Queries.GetItemsByListId;

namespace SimpleList.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<ItemViewModel>
    {
        public int? Id { get; set; }
        public int? ListId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? Quantity { get; set; }
    }
}
