using AutoMapper;
using DotnetPatterns.DataService.Repositories.Interfaces;

namespace DotnetPatterns.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}