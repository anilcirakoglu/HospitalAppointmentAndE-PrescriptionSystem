using Hospital.EntityLayer.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BusinessLayer.Abstract
{
    public interface IUserService
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<User> GetByIdentityNumberAsync(string identityNumber);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);

    }
}
