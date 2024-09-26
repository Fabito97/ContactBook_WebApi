using DGNET002_Week9_10_Task.DTO.Contact;
using DGNET002_Week9_10_Task.Helper;
using DGNET002_Week9_10_Task.Interfaces;
using DGNET002_Week9_10_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DGNET002_Week9_10_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IPhotoService _photoService;
        public UserController(IUserRepository userRepository, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _photoService = photoService;
        }

        [HttpGet("contacts/page")]
        public async Task<IActionResult> GetAll(PaginationParams paginationParams)
        {
            int totalContacts = await _userRepository.GetCountAsync();

            int totalPages = (int)Math.Ceiling((double)totalContacts / paginationParams.PageSize);

            var contacts = _userRepository.GetContacts(paginationParams);

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

            var contacts = await _userRepository.SearchContacts(queryParams);

            return Ok(contacts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            if (id == 0) return BadRequest("id cannot be zero");

            var contact = await _userRepository.GetContactById(id);

            if (contact == null) return BadRequest("Cannot find contact");

            return Ok(contact);
        }

        [HttpPost("create")]
        public IActionResult CreateContact([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest();

            _userRepository.Add(user);
            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<IActionResult> EditContact([FromBody] CreateContactDTO contactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                FirstName = contactDTO.FirstName,
                LastName = contactDTO.LastName,
                PhoneNumber = contactDTO.PhoneNumber,
                Address = contactDTO.Address,
            };


            _userRepository.UpdateContact(user);

            return Ok(user);

        }

        [HttpPatch("{id}/upload-photo")]
        public async Task<IActionResult> UploadPhoto(int id, IFormFile photo)
        {
            if (photo == null || photo.Length == 0) return BadRequest("No photo file uploaded.");

            var user = await _userRepository.GetContactById(id);

            if (user == null)
            {
                return NotFound($"No user found with ID = {id}");
            }

            var uploadResult = await _photoService.AddPhotoAsync(photo);

            if (uploadResult == null)
            {
                return StatusCode(500, "Photo upload failed");
            }
            user.ProfileImage = uploadResult.Url.AbsoluteUri;

            _userRepository.UpdateContact(user);

            return Ok(new
            {
                Message = "Photo uploaded Successfully.",
                PhotoUrl = user.ProfileImage
            });

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var user = await _userRepository.GetContactById(id);

            if (user == null) return BadRequest("Cannot find user to delete");

            _userRepository.Delete(user);

            return Ok("User deleted successfully");
        }

    }
}
