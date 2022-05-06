namespace SimpleList.Domain.Common
{
    public class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int CreationUserId { get; set; } = 1;
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? LastModifiedUserId { get; set; }
    }
}
