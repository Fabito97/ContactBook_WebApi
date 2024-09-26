using DGNET002_Week9_10_Task.Helper;
using DGNET002_Week9_10_Task.Models;

namespace DGNET002_Week9_10_Task.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        IQueryable<User> GetAllContacts();
        Task<User> GetContactById(int id);
        Task<IEnumerable<User>> GetContacts(PaginationParams pageParams);
        Task<int> GetCountAsync();
        bool Save();
        Task<IEnumerable<User>> SearchContacts(QueryParams queryParams);
        void UpdateContact(User user);
    }
}