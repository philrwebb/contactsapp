using System.Text.Json;
using AutoMapper;
using Contacts.Entities;
using Contacts.Models;
using Contacts.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<ContactsController> _logger;

        const int maxPageSize = 20;

        public ContactsController(
            IContactRepository contactRepository,
            IMapper mapper,
            ILogger<ContactsController> logger
        )
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>>
        GetContacts(
            string? name,
            string? searchQuery,
            int pageNumber = 1,
            int pageSize = 10
        )
        {
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }
            var (contacts, PaginationMetadata) =
                await _contactRepository
                    .GetContacts(name, searchQuery, pageNumber, pageSize);

            Response
                .Headers
                .Add("X-Pagination",
                JsonSerializer.Serialize(PaginationMetadata));

            return Ok(_mapper.Map<IEnumerable<ContactDto>>(contacts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ContactDto>(contact));
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>>
        CreateContactAsync(ContactCreateDto contactCreateDto)
        {
            var contact = _mapper.Map<Contact>(contactCreateDto);
            await _contactRepository.CreateContactAsync(contact);
            if (await _contactRepository.SaveChangesAsync())
            {
#pragma warning disable CA2253
                _logger
                    .LogInformation("Contact {0} {1} {2} was created",
                    contact.ContactId,
                    contact.FirstName,
                    contact.LastName);


#pragma warning restore CA2253
                return Ok(_mapper.Map<ContactDto>(contact));
            }


#pragma warning disable CA2253
            _logger
                .LogInformation("Contact {0} {1} {2} was not created",
                contact.ContactId,
                contact.FirstName,
                contact.LastName);


#pragma warning restore CA2253
            return BadRequest("Could not create contact");
        }

        [HttpPatch("{contactId}")]
        public async Task<ActionResult>
        PartialUpdateContact(
            int contactId,
            JsonPatchDocument<ContactUpdateDto> patchDocument
        )
        {
            var contact =
                await _contactRepository.GetContactByIdAsync(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            var contactToPatch = _mapper.Map<ContactUpdateDto>(contact);
            patchDocument.ApplyTo (contactToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(contactToPatch))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map (contactToPatch, contact);
            if (await _contactRepository.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Could not update contact");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactAsync(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            _contactRepository.DeleteContact (contact);
            if (await _contactRepository.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Could not delete contact");
        }
    }
}
