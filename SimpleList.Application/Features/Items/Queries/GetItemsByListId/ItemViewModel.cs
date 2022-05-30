namespace SimpleList.Application.Features.Items.Queries.GetItemsByListId
{
    public class ItemViewModel
    {
        public int? Id { get; set; }
        public int? ListId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? Quantity { get; set; }
    }
}
