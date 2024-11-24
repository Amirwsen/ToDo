using Application.Interfaces;
using Domain.Requests;
using Domain.Responses;

namespace Application.UseCases;

public class UpdateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskInfo> UpdateTask(Guid id, TaskUpdateRequest request, CancellationToken cancellationToken)
    {
        var result = await _taskRepository.UpdateTask(id, request, cancellationToken);
        return result;
    }
}