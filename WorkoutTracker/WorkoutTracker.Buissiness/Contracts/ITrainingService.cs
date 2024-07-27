using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.Buissiness.Services.Trainings.Requests;
using WorkoutTracker.Buissiness.Services.Trainings.Responses;
using WorkoutTracker.DAL.Entities.Trainings;

namespace WorkoutTracker.Buissiness.Contracts;
public interface ITrainingService
{
    Task AddTrainingAsync(TrainingRequest request);
    Task<TrainingResponse> GetTrainingsByUserId(Guid userId);
}
