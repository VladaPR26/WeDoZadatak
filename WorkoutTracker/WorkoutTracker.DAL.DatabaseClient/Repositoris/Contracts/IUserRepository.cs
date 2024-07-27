using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
public interface IUserRepository
{
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
}
