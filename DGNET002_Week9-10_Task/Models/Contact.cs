namespace DGNET002_Week9_10_Task.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Address { get; set; }
        public string PhoneNumber {  get; set; }
        public string? ContactPhoto { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
