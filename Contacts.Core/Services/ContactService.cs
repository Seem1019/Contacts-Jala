using Contacts.Core.CustomEntities;
using Contacts.Core.Entities;
using Contacts.Core.Exceptions;
using Contacts.Core.Interfaces;
using Contacts.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Contacts.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public ContactService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public async Task<Contact> GetContact(int id)
        {
            return await _unitOfWork.ContactRepository.GetById(id);
        }
        public async Task<Contact> GetContactByName(string name)
        {

            return await _unitOfWork.ContactRepository.FindByName(name);
        }
        public async Task<Contact> GetContactByEmail(string email)
        {

            return await _unitOfWork.ContactRepository.FindByEmail(email);
        }

        public PagedList<Contact> GetContacts(ContactQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            if (filters.Id == 0)
            {
                throw new RequiredFieldException("Id is required");
            } 

            var contacts = _unitOfWork.ContactRepository.GetAll(filters.Id).Result;

            if (filters.Name != null)
            {
                contacts = contacts.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            }


            if (filters.Email != null)
            {
                contacts = contacts.Where(x => x.Email.ToLower().Contains(filters.Email.ToLower()));
            }

            var pagedContacts = PagedList<Contact>.Create(contacts, filters.PageNumber, filters.PageSize);
            return pagedContacts;
        }

        public async Task InsertContact(Contact contact)
        {
            var user = await _unitOfWork.UserRepository.GetById(contact.UserId);
            if (user == null)
            {
                throw new BusinessException("User doesn't exist");
            }

            var userContact = await _unitOfWork.ContactRepository.FindByEmail(contact.Email);
            if (userContact is not null)
            {
                throw new DuplicatedContactException("There is a registered contact with this email");
            }


            await _unitOfWork.ContactRepository.Add(contact);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            var existingContact = await _unitOfWork.ContactRepository.GetById(contact.Id);
            if (existingContact is null) throw new ContactNotFoundException("Contact not found");
            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;

            _unitOfWork.ContactRepository.Update(existingContact);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContact(int id)
        {
            await _unitOfWork.ContactRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
