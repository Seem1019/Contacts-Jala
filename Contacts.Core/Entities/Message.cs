namespace Contacts.Core.Entities
{
    public class Message: BaseEntity
    {
        public long UserId { get; set; }
        public long ContactId { get; set; } 
        public string? message { get; set; }
        public DateTimeOffset? date { get; set; }=DateTimeOffset.Now;

        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }
    }
}
