﻿using DGNET002_Week9_10_Task.DTO.Contact;
using DGNET002_Week9_10_Task.Helper;
using DGNET002_Week9_10_Task.Interfaces;
using DGNET002_Week9_10_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGNET002_Week9_10_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IPhotoService _photoService;
        public ContactController(IContactRepository contactRepository, IPhotoService photoService)
        {
            _contactRepository = contactRepository;
            _photoService = photoService;
        }

        [HttpGet("contacts/page")]
        public async Task<IActionResult> GetAll(PaginationParams paginationParams)
        {
            int totalContacts = await _contactRepository.GetCountAsync();

            int totalPages = (int)Math.Ceiling((double)totalContacts / paginationParams.PageSize);            

            var contacts = _contactRepository.GetContacts(paginationParams);

            var response = new
            {
                TotalContacts = totalContacts,
                paginationParams.PageSize,
                CurrentPage = paginationParams.Page,
                TotalPages = totalPages,
                Contacts = contacts,
            };

            return Ok(response);
        }

        [HttpGet("contacts/search-term")]
        public async Task<IActionResult> GetSearchedContact(QueryParams queryParams)
        {
            if (queryParams == null)
            {
                return BadRequest("Please input a search term");
            }

            var contacts = await _contactRepository.SearchContacts(queryParams);

            return Ok(contacts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            if (id == 0) return BadRequest("id cannot be zero");

            var contact = await _contactRepository.GetContactById(id);

            if (contact == null) return BadRequest("Cannot find contact");

            return Ok(contact);
        }

        [HttpPost("create")]
        public IActionResult CreateContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid) return BadRequest();

            _contactRepository.Add(contact);
            return Ok(contact);
        }

        [HttpPut("update")]
        public async Task<IActionResult> EditContact([FromBody] CreateContactDTO contactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = new Contact
            {
                FirstName = contactDTO.FirstName,
                LastName = contactDTO.LastName,
                PhoneNumber = contactDTO.PhoneNumber,
                Address = contactDTO.Address,
            };


            _contactRepository.UpdateContact(contact);

            return Ok(contact);

        }

        [HttpPatch("{id}/upload-photo")]
        public async Task<IActionResult> UploadPhoto(int id, IFormFile photo)
        {
            if (photo == null || photo.Length == 0) return BadRequest("No photo file uploaded.");

            var contact = await _contactRepository.GetContactById(id);

            if (contact == null)
            {
                return NotFound($"No contact found with ID = {id}");
            }

            var uploadResult = await _photoService.AddPhotoAsync(photo);

            if (uploadResult == null)
            {
                return StatusCode(500, "Photo upload failed");
            }
            contact.ContactPhoto = uploadResult.Url.AbsoluteUri;

            _contactRepository.UpdateContact(contact);

            return Ok(new 
            { 
                Message = "Photo uploaded Successfully.", 
                PhotoUrl = contact.ContactPhoto 
            });

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepository.GetContactById(id);

            if (contact == null) return BadRequest("Cannot find contact to delete");

            _contactRepository.Delete(contact);

            return Ok("Contact deleted successfully");
        }

    }
}
