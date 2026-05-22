using AutoMapper;
using MediatR;
using taskManagement.entity;
using TaskManagmentApplication.command;
using TaskManagmentApplication.DTO.response;

public class CreateProjectHandler : IRequestHandler<CreateprojectCommand, GetProjectResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unit;

    public CreateProjectHandler(IMapper mapper, IUnitOfWork unit)
    {
        _mapper = mapper;
        _unit = unit;
    }

   

    public async Task<GetProjectResponse> Handle(CreateprojectCommand request, CancellationToken cancellationToken)
    {
        
        var entity = _mapper.Map<Project>(request.request);
        var created = await _unit.Projects.CreateAsync(entity);
        var createdProject=_mapper.Map<GetProjectResponse>(created);
        await _unit.SaveAsync();
        return createdProject;

    }
}