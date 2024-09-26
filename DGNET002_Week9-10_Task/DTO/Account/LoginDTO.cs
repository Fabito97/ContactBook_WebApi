using System.ComponentModel.DataAnnotations;

namespace DGNET002_Week9_10_Task.DTO.Account
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
