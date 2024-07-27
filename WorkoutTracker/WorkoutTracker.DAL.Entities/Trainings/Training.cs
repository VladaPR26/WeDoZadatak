using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.DAL.Entities.Trainings;
public class Training
{
    public Guid TrainingId { get; set; }
    public Guid UserId {  get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Intensity { get; set; }
    public int PhysicalFatigue { get; set; }
    public int CaloriesBurned { get; set; }
    public TimeSpan DurationTime { get; set; }
    public ExerciseType Exercise { get; set; }
    public DateTime Date { get; set; }
}
