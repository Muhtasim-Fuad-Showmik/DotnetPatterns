using AutoMapper;
using DotnetPatterns.Api.Commands;
using DotnetPatterns.Api.Queries;
using DotnetPatterns.DataService.Repositories.Interfaces;
using DotnetPatterns.Entities.DbSet;
using DotnetPatterns.Entities.Dtos.Requests;
using DotnetPatterns.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPatterns.Api.Controllers;

public class DriversController : BaseController
{
    private readonly IMediator _mediator;
    
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) 
        : base(unitOfWork, mapper)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        // Specifying the query for this endpoint
        var query = new GetDriverQuery(driverId);

        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        // Specifying the query for this endpoint
        var query = new GetAllDriversQuery();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new CreateDriverInfoRequest(driver);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new {driverId = result.DriverId}, result);
    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver == null)
            return NotFound();

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}