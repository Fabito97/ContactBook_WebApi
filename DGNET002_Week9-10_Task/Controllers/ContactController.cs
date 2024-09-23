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
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactRepository.GetContacts();
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
        public async Task<IActionResult> EditContact([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.UpdateContact(contact);

                return Ok(contact);
            }

            return BadRequest("Cannot find contact to update");            
            
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
