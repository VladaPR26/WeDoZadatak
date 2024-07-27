using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.DAL.Entities.Trainings;

namespace WorkoutTracker.Buissiness.Services.Trainings.Requests;
public class TrainingRequest
{
    public Guid UserId { get; set; }

    [Required(ErrorMessage ="Training name required")]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Intensity required")]
    [Range(1, 10, ErrorMessage = "The value must be between 1 and 10.")]
    public int Intensity { get; set; }

    [Required(ErrorMessage = "Fatigue required")]
    [Range(1, 10, ErrorMessage = "The value must be between 1 and 10.")]
    public int PhysicalFatigue { get; set; }

    [Required(ErrorMessage = "Calories required")]
    public int CaloriesBurned { get; set; }

    [Required(ErrorMessage = "Duration Time required")]
    public TimeSpan DurationTime { get; set; } 

    [Required(ErrorMessage = "Exercise required")]
    public ExerciseType Exercise { get; set; }

    [Required(ErrorMessage = "Date required")]
    public DateTime Date { get; set; }
}
