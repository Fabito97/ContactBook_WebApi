﻿using Microsoft.AspNetCore.Identity;

namespace DGNET002_Week9_10_Task.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set;}
        public string? ProfileImage {  get; set;}
        public List<Contact> Contacts { get; set;}


    }
}
