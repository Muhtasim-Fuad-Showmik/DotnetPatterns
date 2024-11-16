using MediatR;

namespace DotnetPatterns.Api.Commands;

public class DeleteDriverInfoRequest : IRequest<bool>
{
    public Guid DriverId { get; }

    public DeleteDriverInfoRequest(Guid driverId)
    {
        DriverId = driverId;
    }
}