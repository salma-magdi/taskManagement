using AutoMapper;
using MediatR;
using taskManagement.entity;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;
using TaskManagmentApplication.query;

namespace TaskManagmentApplication.Handler
{
    public class GetTasksInProjectHandler
        : IRequestHandler<
            GetTaskByProjectQuery,
            generalApiResponse<IEnumerable<GetTaskResponse>>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public GetTasksInProjectHandler(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public async Task<generalApiResponse<IEnumerable<GetTaskResponse>>> Handle(
            GetTaskByProjectQuery request,
            CancellationToken cancellationToken)
        {
            var tasks = await unit.Tasks
                .GetTasksByProjectIdAsync(request.ProjectId);

            var result = mapper.Map<IEnumerable<GetTaskResponse>>(tasks);

            return generalApiResponse<IEnumerable<GetTaskResponse>>
                .SuccessResult(result, "Tasks retrieved successfully");
        }
    }
}