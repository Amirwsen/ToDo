using Application.Interfaces;

namespace Application.UseCases;

public class DeleteTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<string> DeleteTask(Guid id, CancellationToken cancellationToken)
    {
        var result = await _taskRepository.DeleteTask(id, cancellationToken);
        return result;
    }
}