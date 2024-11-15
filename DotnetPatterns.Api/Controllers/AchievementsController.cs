using AutoMapper;
using DotnetPatterns.DataService.Repositories.Interfaces;
using DotnetPatterns.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPatterns.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

        if (driverAchievements == null)
            return NotFound("Achievements not found");

        var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);

        return Ok(result);
    }
}