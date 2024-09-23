using DGNET002_Week9_10_Task.Models;

namespace DGNET002_Week9_10_Task.Interfaces
{
    public interface IContactRepository
    {
        public Task<IEnumerable<Contact>> GetContacts();
        public Task<Contact> GetContactById(int id);
        public void Add(Contact contact);   
        public void Delete(Contact contact);
        public void UpdateContact(Contact contact);
        public bool Save();
    }
}
