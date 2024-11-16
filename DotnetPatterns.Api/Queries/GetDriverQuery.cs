using DotnetPatterns.Entities.Dtos.Responses;
using MediatR;

namespace DotnetPatterns.Api.Queries;

public class GetDriverQuery : IRequest<GetDriverResponse>
{
    public Guid DriverId { get; }

    public GetDriverQuery(Guid driverId)
    {
        DriverId = driverId;
    }
}