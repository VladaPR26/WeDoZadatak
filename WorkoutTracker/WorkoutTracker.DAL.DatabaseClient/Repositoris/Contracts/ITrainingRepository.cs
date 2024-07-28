using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.DAL.Entities.Trainings;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
public interface ITrainingRepository
{
    Task AddTrainingAsync(Training training);
    Task<IEnumerable<Training>> GetTrainingsByUserId(Guid userId);
    Task<IEnumerable<Training>> GetTrainingsByMonth(int month);
}
