using SimpleList.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleList.Domain
{
    public class Item : BaseDomainModel
    {
        public string Description { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public int ListId { get; set; }

        [ForeignKey(nameof(ListId))]
        public virtual List List { get; set; }
    }
}
