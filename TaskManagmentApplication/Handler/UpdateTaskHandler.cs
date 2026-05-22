using MediatR;
using taskManagement.entity;
using TaskManagmentApplication.command;

public class UpdateTaskStatusHandler
    : IRequestHandler<UpdateTaskStatusCommand, bool>
{
    private readonly IUnitOfWork _unit;

    public UpdateTaskStatusHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<bool> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _unit.Tasks.GetByIdAsync(request.TaskId);

        if (task == null)
            return false;

        task.Status = request.Status;

        await _unit.Tasks.UpdateAsync(task);
        await _unit.SaveAsync();
        return true;
    }
}