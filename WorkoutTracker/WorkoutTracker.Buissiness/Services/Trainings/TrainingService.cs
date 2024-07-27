using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.Buissiness.Contracts;
using WorkoutTracker.Buissiness.Services.Trainings.Requests;
using WorkoutTracker.Buissiness.Services.Trainings.Responses;
using WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
using WorkoutTracker.DAL.Entities.Trainings;

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

    public async Task<TrainingResponse> GetTrainingsByUserId(Guid userId)
    {
        List<Training> trainings= (await _trainingRepository.GetTrainingsByUserId(userId)).ToList();
        TrainingResponse response = new TrainingResponse
        {
            trainings = trainings
        }; 
        return response;
    }
}
