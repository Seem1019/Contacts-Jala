using AutoMapper;
using Contacts.Controllers;
using Contacts.Core.CustomEntities;
using Contacts.Core.DTOs;
using Contacts.Core.Entities;
using Contacts.Core.Exceptions;
using Contacts.Core.Interfaces;
using Contacts.Core.Services;
using Contacts.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;

namespace Contacts.UnitTest
{
    public class GetContact
    {

        protected IContactService _contactServiceMock { get; set; }
        protected Mock<IUnitOfWork> _unitOfWorkMock { get; set; }
        protected Mock<IOptions<PaginationOptions>> options { get; set; }

        public GetContact()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            options = new Mock<IOptions<PaginationOptions>>();
            _contactServiceMock = new ContactService(_unitOfWorkMock.Object, options.Object);
        }

        public class ReturnValue : GetContact
        {
            public ReturnValue()
            {
                _unitOfWorkMock.Setup(s => s.ContactRepository.FindByEmail("stevene@algo.com"))
                    .Returns(
                        new Contact
                        {
                            Id = new Random().NextInt64(),
                            Email = "algo@algo.com",
                            UserId = new Random().NextInt64(),
                            Name = "Juan"
                        }.GetType).Verifiable();
                _unitOfWorkMock.Setup(s => s.UserRepository.GetById(1))
                    .Returns(
                        new User
                        {
                            Id = 1,
                            FullName = "juan",
                            IsActive = true
                        }
                        .GetType).Verifiable();
            }
        }
        [Fact]
        public async void getContactByEmail_EmailTest_ReturnContact()
        {
            //Arrange

            //Act
            //Asert
        }

        [Fact]
        public async void contactDuplicate()
        {
            //Arrange

            var user = new User
            {
                Id = (new Random().NextInt64()),
                FullName = "juan",
                IsActive = true
            };
            var contactDto =  new ContactDto
            {
                UserId = user.Id,
                Name = "pedro",
                Email = "algo@algo.com"
            };
            var contact = new Contact
            {
                Id = 1,
                UserId = 1,
                Name = "pedro",
                Email = "stevene@algo.com"
            };
            user.Contacts.Add(contact);

            //Act
             Action action = async ()=>  await _contactServiceMock.InsertContact(contact);
            //Asert
            Assert.Throws<DuplicatedContactException>(action);

            

        }


    }
}
