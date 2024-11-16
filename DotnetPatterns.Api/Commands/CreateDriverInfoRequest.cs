using DotnetPatterns.Entities.Dtos.Requests;
using DotnetPatterns.Entities.Dtos.Responses;
using MediatR;

namespace DotnetPatterns.Api.Commands;

public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; }

    public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
    {
        DriverRequest = driverRequest;
    }
}