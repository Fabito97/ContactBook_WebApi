using DGNET002_Week9_10_Task.Helper;
using DGNET002_Week9_10_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNET002_Week9_10_Task.Interfaces
{
    public interface IContactRepository
    {
        public Task<int> GetCountAsync();
        public IQueryable<Contact> GetAllContacts();
        public Task<IEnumerable<Contact>> GetContacts(PaginationParams pageParams);
        public Task<IEnumerable<Contact>> SearchContacts(QueryParams queryParams);       
        Task<Contact> GetContactById(int id);
        void Add(Contact contact);   
        void Delete(Contact contact);
        void UpdateContact(Contact contact);
        bool Save();
    }
}
