using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WorkoutTracker.DAL.DatabaseClient.Migrations;
using WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.DAL.DatabaseClient.Repositoris;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddUserAsync(User user)
    {
        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users
       .Where(user => user.Email == email)
       .FirstOrDefaultAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Set<User>().FindAsync(id);
    }
}
