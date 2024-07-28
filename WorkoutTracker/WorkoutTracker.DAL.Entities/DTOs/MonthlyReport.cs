using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.DAL.Entities.DTOs;
public class MonthlyReport
{
    public Dictionary<int, WeeklyReport> Report { get; set; }=new Dictionary<int, WeeklyReport>();
}
