namespace Contacts.Core.Exceptions
{
    public class RequiredFieldException : Exception
    {
        public RequiredFieldException(string message) : base(message)
        {
        }
    }
}
