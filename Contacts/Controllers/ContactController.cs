using AutoMapper;
using Contacts.Core.CustomEntities;
using Contacts.Core.DTOs;
using Contacts.Core.Entities;
using Contacts.Core.Interfaces;
using Contacts.Core.QueryFilters;
using Contacts.Infrastructure.Interfaces;
using Contacts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Contacts.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IUriService uriService, IMapper mapper)
        {
            _contactService = contactService;
            _uriService = uriService;
            _mapper = mapper;
        }


        /// <summary>
        /// Retrieve all contacts
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetContacts))]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ContactDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetContacts([FromQuery] ContactQueryFilter filters)
        {
            var contacts = _contactService.GetContacts(filters);
            var contactsDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            var metadata = new Metadata
            {
                TotalCount = contacts.TotalCount,
                PageSize = contacts.PageSize,
                CurrentPage = contacts.CurrentPage,
                TotalPages = contacts.TotalPages,
                HasNextPage = contacts.HasNextPage,
                HasPreviousPage = contacts.HasPreviousPage,
                NextPageUrl = _uriService.GetContactPaginationUri(filters, Url.RouteUrl(nameof(GetContacts))).ToString(),
                PreviousPageUrl = _uriService.GetContactPaginationUri(filters, Url.RouteUrl(nameof(GetContacts))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ContactDto>>(contactsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        [HttpGet("ByName")]
        [Authorize]
        public async Task<IActionResult> GetContactByName([FromQuery] string name)
        {
            var contact = await _contactService.GetContactByName(name);
            var contactDto = _mapper.Map<ContactDto>(contact);
            var response = new ApiResponse<ContactDto>(contactDto);
            return Ok(response);
        }

        [HttpGet("ByEmail")]
        [Authorize]
        public async Task<IActionResult> GetContactByEmail([FromQuery] string email)
        {
            var contact = await _contactService.GetContactByEmail(email);
            var contactDto = _mapper.Map<ContactDto>(contact);
            var response = new ApiResponse<ContactDto>(contactDto);
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Contact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactService.InsertContact(contact);

            contactDto = _mapper.Map<ContactDto>(contact);
            var response = new ApiResponse<ContactDto>(contactDto);
            return Ok(response);
        }
    }
}
