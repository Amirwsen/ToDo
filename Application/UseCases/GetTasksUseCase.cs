using Application.Interfaces;
using Domain.Responses;

namespace Application.UseCases;

public class GetTasksUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<(List<TaskInfo>, int)> GetTasks(CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasks(cancellationToken);
        return (tasks);
    }
}