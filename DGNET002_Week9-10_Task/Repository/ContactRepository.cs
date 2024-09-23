using DGNET002_Week9_10_Task.Data;
using DGNET002_Week9_10_Task.Interfaces;
using DGNET002_Week9_10_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNET002_Week9_10_Task.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public void Add(Contact contact)
        {
            _context.Add(contact);
            Save();
        }

        public void UpdateContact(Contact contact)
        {           
            _context.Update(contact);
            Save();
        }

        public void Delete(Contact contact)
        {            
            _context.Remove(contact);
            Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        
    }
}
