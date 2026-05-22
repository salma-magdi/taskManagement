using MediatR;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.DTO.response;

namespace TaskManagmentApplication.command
{
    public class UpdateProjectCommand : IRequest<GetProjectResponse>
    {
        public int Id { get; set; }

        public UpdateProjectRequest Request { get; set; }

        public UpdateProjectCommand(int id, UpdateProjectRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}