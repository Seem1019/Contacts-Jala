namespace Contacts.Core.Exceptions
{
    public class DuplicatedContactException : Exception
    {
        public DuplicatedContactException(string message) : base(message)
        {
        }
    }
}
