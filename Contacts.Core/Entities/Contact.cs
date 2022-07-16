namespace Contacts.Core.Entities
{
    public class Contact:BaseEntity
    {
        public Contact()
        {
            Messages = new HashSet<Message>();
        }
        public long UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
