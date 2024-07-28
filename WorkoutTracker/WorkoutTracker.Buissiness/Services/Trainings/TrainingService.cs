using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.Buissiness.Contracts;
using WorkoutTracker.Buissiness.Services.Trainings.Requests;
using WorkoutTracker.Buissiness.Services.Trainings.Responses;
using WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
using WorkoutTracker.DAL.Entities.DTOs;
using WorkoutTracker.DAL.Entities.Trainings;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.Buissiness.Services.Trainings;
public class TrainingService : ITrainingService {

    private readonly ITrainingRepository _trainingRepository;
    public TrainingService(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public async Task AddTrainingAsync(TrainingRequest request)
    {
        Training training = new Training
        {
            TrainingId = Guid.NewGuid(),
            UserId = request.UserId,
            Name = request.Name,
            Description = request.Description,
            Intensity = request.Intensity,
            PhysicalFatigue = request.PhysicalFatigue,
            CaloriesBurned = request.CaloriesBurned,
            DurationTime = request.DurationTime,
            Exercise = request.Exercise,
            Date = request.Date
        };
       await _trainingRepository.AddTrainingAsync(training);
    }

    public async Task<Dictionary<int, List<Training>>> GetTrainingsByWeeksInMonthAsync(int month)
    {
        List<Training> trainings = (await _trainingRepository.GetTrainingsByMonth(month)).ToList();
        // Find the first day of the month
        var firstDayOfMonth = new DateTime(2024, month, 1);
        var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        var firstWeekStart = firstDayOfMonth;

        // Calculate the starting date of the first week
        if (firstDayOfMonth.DayOfWeek != firstDayOfWeek)
        {
            var diff = (7 + (firstDayOfMonth.DayOfWeek - firstDayOfWeek)) % 7;
            firstWeekStart = firstDayOfMonth.AddDays(-diff);
        }

        // Group trainings by the week number within the month
        var trainingsByWeek = trainings
            .GroupBy(training =>
            {
                var weekNumber = (training.Date - firstWeekStart).Days / 7 + 1;
                return weekNumber;
            })
            .ToDictionary(g => g.Key, g => g.ToList());

        return trainingsByWeek;
    }

    public async Task<TrainingResponse> GetTrainingsByUserId(Guid userId)
    {
        List<Training> trainings= (await _trainingRepository.GetTrainingsByUserId(userId)).ToList();
        TrainingResponse response = new TrainingResponse
        {
            trainings = trainings
        }; 
        return response;
    }

    public async Task<MonthlyReport> CalculateMonthlyReport(int month)
    {
        MonthlyReport monthlyReport=new MonthlyReport();
        var trainingWeeks=await GetTrainingsByWeeksInMonthAsync(month);

        TimeSpan trainingDuration = new TimeSpan(0, 0, 0);
        int trainingCount = 0;
        float trainingAverageIntensity = 0;
        float trainingAveragePhysicalFatigue = 0;

        foreach (var trainings in trainingWeeks)
        {
            int key=trainings.Key;
            trainingCount=trainings.Value.Count();
            
            foreach(var training in trainings.Value)
            {
                trainingAverageIntensity += training.Intensity;
                trainingAveragePhysicalFatigue += training.PhysicalFatigue;
                trainingDuration += training.DurationTime;
            }
            trainingAverageIntensity /= trainingCount;
            trainingAveragePhysicalFatigue /= trainingCount;
            trainingDuration /= trainingCount;

            WeeklyReport weeklyReport = new WeeklyReport
            {
                TrainingCount = trainingCount,
                TrainingAverageIntensity = trainingAverageIntensity,
                TrainingAveragePhysicalFatigue = trainingAveragePhysicalFatigue,
                TrainingDurations = trainingDuration
            };
            monthlyReport.Report.Add(key, weeklyReport);
            trainingAverageIntensity = 0;
            trainingAveragePhysicalFatigue = 0;
            trainingDuration = new TimeSpan(0,0,0);
        }



        return monthlyReport;
    }
}
