using AutoMapper;
using MediatR;
using taskManagement.entity;
using TaskManagmentApplication.command;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;

public class CreateProjectHandler
    : IRequestHandler<CreateprojectCommand, generalApiResponse<GetProjectResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unit;

    public CreateProjectHandler(IMapper mapper, IUnitOfWork unit)
    {
        _mapper = mapper;
        _unit = unit;
    }

    public async Task<generalApiResponse<GetProjectResponse>> Handle(
        CreateprojectCommand request,
        CancellationToken cancellationToken)
    {
        // request -> entity
        var entity = _mapper.Map<Project>(request.request);

        // save project
        var created = await _unit.Projects.CreateAsync(entity);

        await _unit.SaveAsync();

        // entity -> response dto
        var response = _mapper.Map<GetProjectResponse>(created);

        // wrap response
        return generalApiResponse<GetProjectResponse>.SuccessResult(
            response,
            "Project created successfully"
        );
    }
}