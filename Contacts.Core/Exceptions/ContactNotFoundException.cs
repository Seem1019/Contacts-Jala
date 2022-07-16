namespace Contacts.Core.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message)
        {
        }
    }
}
