using Domain.Entities;
using Domain.Requests;
using Domain.Responses;

namespace Application.Interfaces;

public interface ITaskRepository
{
    Task<ToDo> CreateTask(TaskRequest taskRequest, CancellationToken cancellationToken);
    Task<(List<TaskInfo>, int)> GetTasks(CancellationToken cancellationToken);
    Task<TaskInfo> GetTask(Guid id, CancellationToken cancellationToken);
    Task<TaskInfo> UpdateTask(Guid id, TaskUpdateRequest request, CancellationToken cancellationToken);
    Task<string> DeleteTask(Guid id, CancellationToken cancellationToken);
}