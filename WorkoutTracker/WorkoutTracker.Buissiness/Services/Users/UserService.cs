using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Microsoft.IdentityModel.Tokens;

using WorkoutTracker.Buissiness.Contracts;
using WorkoutTracker.Buissiness.Services.Users.Requests;
using WorkoutTracker.Buissiness.Services.Users.Responses;
using WorkoutTracker.DAL.DatabaseClient.Repositoris.Contracts;
using WorkoutTracker.DAL.Entities.Users;

namespace WorkoutTracker.Buissiness.Services.Users;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    public async Task Register(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
        if(existingUser != null) 
        {
            throw new ArgumentException("User with this email already exists");
        }
        var user = new User
        {
            Id=Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            Lastname=request.Lastname,
            Password=BCrypt.Net.BCrypt.HashPassword(request.Password),
        };

        await _userRepository.AddUserAsync(user);
    }
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if(user == null) {
            throw new ArgumentException("User with this email does not exists");
        }
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new ArgumentException("Wrong password");
        }
        var token = GenerateToken(user, _configuration);
        LoginResponse response = new LoginResponse
        {
            Token = token
        };
        return response;
    }

    private string GenerateToken(User user, IConfiguration configuration)
    {
        //Generate token that is valid for 5 days
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
                new Claim("user_id", user.Id.ToString()),
                new Claim("user_name", user.Name),
                new Claim("user_email", user.Email),
                };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: userClaims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddDays(5)
        );

        return tokenHandler.WriteToken(token);
    }

}
