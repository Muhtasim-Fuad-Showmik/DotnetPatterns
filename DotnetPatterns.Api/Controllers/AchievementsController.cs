using AutoMapper;
using DotnetPatterns.DataService.Repositories.Interfaces;

namespace DotnetPatterns.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}