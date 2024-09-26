using DGNET002_Week9_10_Task.Data;
using DGNET002_Week9_10_Task.Helper;
using DGNET002_Week9_10_Task.Interfaces;
using DGNET002_Week9_10_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNET002_Week9_10_Task.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> GetCountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public IQueryable<User> GetAllContacts()
        {
            return _context.Users.AsQueryable();

        }
        public async Task<IEnumerable<User>> GetContacts(PaginationParams pageParams)
        {
            var users = GetAllContacts();

            return await users
                .Skip((pageParams.Page - 1) * pageParams.PageSize)
                .Take(pageParams.PageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchContacts(QueryParams queryParams)
        {
            var users = GetAllContacts();

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
            {
                users = users.Where(c => c.FirstName.Contains(queryParams.Name));
            }
            if (!string.IsNullOrWhiteSpace(queryParams.PhoneNumber))
            {
                users = users.Where(c => c.PhoneNumber.Contains(queryParams.PhoneNumber));
            }
            return await users.ToListAsync();

        }

        public async Task<User> GetContactById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Add(User user)
        {
            _context.Add(user);
            Save();
        }

        public void UpdateContact(User user)
        {
            _context.Update(user);
            Save();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
