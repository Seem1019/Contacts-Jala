using Contacts.Core.DTOs;
using FluentValidation;

namespace Contacts.Infrastructure.Validations
{
    public class ContactValidation : AbstractValidator<ContactDto>
    {
        public ContactValidation()
        {
            RuleFor(contact => contact.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("name cannot be empty or null");
            RuleFor(contact => contact.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email cannot be empty or null");
            RuleFor(contact => contact.Email)
                .EmailAddress()
                .WithMessage("It must be a valid email");
        }
    }
}
