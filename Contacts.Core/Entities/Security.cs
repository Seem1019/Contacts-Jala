namespace Contacts.Core.Entities
{
    public class Security:BaseEntity
    {

        public long UserId { get; set; }
        public string UserName { get; set; }
        
        public virtual User User  { get; set; }

        public string Password { get; set; }
    }
}
