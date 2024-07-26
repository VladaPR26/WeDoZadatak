using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.DAL.Entities.Trainings;

namespace WorkoutTracker.DAL.Entities.Users;
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public string Lastname {  get; set; }=string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; }=string.Empty;

    public ICollection<Training> Trainings { get; set; } = new List<Training>();

}
