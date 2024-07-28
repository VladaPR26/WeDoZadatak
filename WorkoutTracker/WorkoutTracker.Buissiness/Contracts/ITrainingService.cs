using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WorkoutTracker.Buissiness.Services.Trainings.Requests;
using WorkoutTracker.Buissiness.Services.Trainings.Responses;
using WorkoutTracker.DAL.Entities.DTOs;
using WorkoutTracker.DAL.Entities.Trainings;

namespace WorkoutTracker.Buissiness.Contracts;
public interface ITrainingService
{
    Task AddTrainingAsync(TrainingRequest request);
    Task<TrainingResponse> GetTrainingsByUserId(Guid userId);
    Task<Dictionary<int, List<Training>>> GetTrainingsByWeeksInMonthAsync(int month);
    Task<MonthlyReport> CalculateMonthlyReport(int month);

}
