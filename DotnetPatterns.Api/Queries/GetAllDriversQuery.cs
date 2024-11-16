using DotnetPatterns.Entities.Dtos.Responses;
using MediatR;

namespace DotnetPatterns.Api.Queries;

public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
{
    
}