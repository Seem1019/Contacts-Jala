namespace Contacts.Core.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            
            Security=new Security();
            Contacts= new HashSet<Contact>();
            Messages = new HashSet<Message>();
        }
        public string? FullName { get; set; }
        public bool IsActive { get; set; } = true;


        public virtual Security Security { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }
}
