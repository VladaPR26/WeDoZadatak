using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Buissiness.Services.Trainings.Requests;
public class MonthlyReportRequest
{
    [Required(ErrorMessage ="Month required")]
    public int Month {  get; set; }
    [Required(ErrorMessage = "UserId required")]
    public Guid UserId { get; set; }
}
