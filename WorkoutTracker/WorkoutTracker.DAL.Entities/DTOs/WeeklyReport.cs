using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.DAL.Entities.DTOs;
public class WeeklyReport
{
    public TimeSpan TrainingDurations { get; set; }
    public int TrainingCount { get; set; }
    public float TrainingAverageIntensity { get; set; }
    public float TrainingAveragePhysicalFatigue {  get; set; }
}
