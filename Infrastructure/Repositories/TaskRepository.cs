using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;
using Domain.Requests;
using Domain.Responses;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly DatabaseContext _context;

    public TaskRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ToDo> CreateTask(TaskRequest taskRequest, CancellationToken cancellationToken)
    {
        var result = new ToDo
        {
            Title = taskRequest.Title,
            Description = taskRequest.Description
        };
        await _context.AddAsync(result, cancellationToken);
        await CompleteAsync(cancellationToken);
        return result;
    }

    public async Task<(List<TaskInfo>, int)> GetTasks(CancellationToken cancellationToken)
    {
        var result = await _context.ToDoTable.Select(x => x.ToTaskInfo()).ToListAsync(cancellationToken);
        var count = result.Count();
        return (result, count);
    }

    public async Task<TaskInfo> GetTask(Guid id, CancellationToken cancellationToken)
    {
        var result = await _context.ToDoTable.Where(task => task.Id == id).Select(x => TaskMapper.ToTaskInfo(x))
            .FirstOrDefaultAsync(cancellationToken);
        if (result != null)
        {
            return result;
        }

        throw new Exception("Task not found");
    }

    public async Task<TaskInfo> UpdateTask(Guid id, TaskUpdateRequest request, CancellationToken cancellationToken)
    {
        if (id != null)
        {
            var todo = await _context.ToDoTable.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            todo.Title = request.Title ?? todo.Title;
            todo.Description = request.Description ?? todo.Description;
            await _context.SaveChangesAsync(cancellationToken);
            await CompleteAsync(cancellationToken);
            return todo.ToTaskInfo();
        }
        throw new Exception("Task not found");
    }

    public async Task<string> DeleteTask(Guid id, CancellationToken cancellationToken)
    {
        var task =await _context.ToDoTable.Where(todo => todo.Id == id).FirstAsync(cancellationToken);
        task.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        await CompleteAsync(cancellationToken);
        var message = $"{task.Title} with Id '{task.Id}' has been deleted";
        return message;
    }

    public async Task CompleteAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}