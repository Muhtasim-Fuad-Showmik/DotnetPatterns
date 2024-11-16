using AutoMapper;
using DotnetPatterns.Api.Commands;
using DotnetPatterns.DataService.Repositories.Interfaces;
using DotnetPatterns.Entities.DbSet;
using DotnetPatterns.Entities.Dtos.Responses;
using MediatR;

namespace DotnetPatterns.Api.Handlers;

public class CreateDriverInfoHandler : IRequestHandler<CreateDriverInfoRequest, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDriverInfoHandler(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = _mapper.Map<Driver>(request.DriverRequest);

        await _unitOfWork.Drivers.Add(driver);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<GetDriverResponse>(driver);
    }
}