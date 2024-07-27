using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkoutTracker.Buissiness.Services.Users.Requests;
using WorkoutTracker.Buissiness.Services.Users.Responses;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.Buissiness.Contracts;
public interface IUserService
{
    Task Register(RegisterRequest request);
    Task<LoginResponse> Login(LoginRequest request);
}
