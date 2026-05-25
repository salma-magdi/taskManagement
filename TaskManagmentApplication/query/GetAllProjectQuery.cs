using MediatR;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.query
{
    public record GetAllProjectQuery
        : IRequest<generalApiResponse<IEnumerable<GetProjectResponse>>>
    {
    }
}