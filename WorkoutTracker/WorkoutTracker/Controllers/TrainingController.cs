using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Buissiness.Contracts;
using WorkoutTracker.Buissiness.Services.Trainings.Requests;
using WorkoutTracker.Buissiness.Services.Trainings.Responses;

namespace WorkoutTracker.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService _trainingService;
    public TrainingController(ITrainingService trainingService)
    {
        _trainingService = trainingService;
    }
    [HttpGet("{userId:Guid}")]
    [Authorize]
    public async Task<ActionResult> GetTrainingsByUserId(Guid userId)
    {
        TrainingResponse response = await _trainingService.GetTrainingsByUserId(userId);
        return Ok(response);
    }

    [HttpPost("calculate")]
    [Authorize]
    public async Task<IActionResult> CalculateMonthlyReport([FromBody] MonthlyReportRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await _trainingService.CalculateMonthlyReport(request.Month,request.UserId);
        return Ok(response);
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddTraining([FromBody] TrainingRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _trainingService.AddTrainingAsync(request);
        return Ok();
    }
}
