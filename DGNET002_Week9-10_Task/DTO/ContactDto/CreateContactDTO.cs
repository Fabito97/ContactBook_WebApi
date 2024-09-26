using System.ComponentModel.DataAnnotations;

namespace DGNET002_Week9_10_Task.DTO.Contact
{
    public class CreateContactDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public string? Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
