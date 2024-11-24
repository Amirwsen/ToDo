using Application.Interfaces;
using Domain.Requests;
using Domain.Responses;

namespace Application.UseCases;

public class GetTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskInfo> GetTask(Guid id, CancellationToken cancellationToken)
    {
        var result = await _taskRepository.GetTask(id, cancellationToken);
        return result;
    } 
}