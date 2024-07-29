using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WorkoutTracker.DAL.DatabaseClient.Migrations;
using WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
using WorkoutTracker.DAL.Entities.Trainings;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.DAL.DatabaseClient.Repositoris;
public class TrainingRepository:ITrainingRepository
{
    private readonly ApplicationDbContext _context;
    public TrainingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddTrainingAsync(Training training)
    {
        await _context.Set<Training>().AddAsync(training);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Training>> GetTrainingsByMonthAndUserId(int month,Guid userId)
    {
        return await _context.Trainings.Where(training =>training.Date.Month==month && training.UserId==userId).ToListAsync();
    }

    public async Task<IEnumerable<Training>> GetTrainingsByUserId(Guid userId)
    {
       return await _context.Trainings.Where(training => training.UserId == userId).ToListAsync();
    }
}
