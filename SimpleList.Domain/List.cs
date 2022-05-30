using SimpleList.Domain.Common;

namespace SimpleList.Domain
{
    public class List: BaseDomainModel
    {
        public string Name { get; set; } = string.Empty;
        public virtual IEnumerable<Item>? Items { get; set; }
    }
}
