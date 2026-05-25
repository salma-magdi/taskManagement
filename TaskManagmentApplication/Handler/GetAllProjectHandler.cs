using AutoMapper;
using MediatR;
using taskManagement.entity;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;
using TaskManagmentApplication.query;

namespace TaskManagmentApplication.Handler
{
    public class GetAllProjectsHandler: IRequestHandler<GetAllProjectQuery,generalApiResponse<IEnumerable<GetProjectResponse>>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public GetAllProjectsHandler(IMapper _mapper, IUnitOfWork _unit)
        {
            mapper = _mapper;
            unit = _unit;
        }

        public async Task<generalApiResponse<IEnumerable<GetProjectResponse>>> Handle(
            GetAllProjectQuery request,
            CancellationToken cancellationToken)
        {
            // get projects
            var entities = await unit.Projects.GetAllProjectsAsync();

            // map entity list -> dto list
            var response = mapper.Map<IEnumerable<GetProjectResponse>>(entities);

            // wrap response
            return generalApiResponse<IEnumerable<GetProjectResponse>>
                .SuccessResult(response, "Projects retrieved successfully");
        }
    }
}