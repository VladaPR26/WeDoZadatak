using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.DAL.Entities.Trainings;

namespace WorkoutTracker.Buissiness.Services.Trainings.Responses;
public class TrainingResponse
{
    public List<Training> trainings {  get; set; }=new List<Training>();
}
