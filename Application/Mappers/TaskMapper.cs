using Domain.Entities;
using Domain.Responses;

namespace Application.Mappers;

public static class TaskMapper
{
    public static TaskInfo ToTaskInfo(this ToDo Todo) => new TaskInfo(Todo.Id, Todo.Title, Todo.Description, Todo.CreatedAt);
}