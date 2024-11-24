using Application.Interfaces;
using Domain.Entities;
using Domain.Requests;

namespace Application.UseCases;

public class CreateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ToDo> CreateTask(TaskRequest taskRequest, CancellationToken cancellationToken)
    {
        var result = await _taskRepository.CreateTask(taskRequest, cancellationToken);
        return result;
    }
}