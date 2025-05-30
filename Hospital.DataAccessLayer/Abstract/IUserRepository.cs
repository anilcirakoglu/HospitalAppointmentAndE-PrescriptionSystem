using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccessLayer.Abstract
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid userId);
        Task<User> GetByIdentityNumberAsync(string identityNumber);
    }
}
