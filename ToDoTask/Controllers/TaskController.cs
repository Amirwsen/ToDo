using Application.UseCases;
using Domain.Entities;
using Domain.Requests;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ToDoTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly CreateTaskUseCase _createTaskUseCase;
    private readonly GetTasksUseCase _getTasksUseCase;
    private readonly GetTaskUseCase _getTask;
    private readonly UpdateTaskUseCase _updateTaskUseCase;
    private readonly DeleteTaskUseCase _deleteTaskUseCase;

    public TaskController(CreateTaskUseCase createTaskUseCase, GetTasksUseCase getTasksUseCase, GetTaskUseCase getTask,
        UpdateTaskUseCase updateTaskUseCase, DeleteTaskUseCase deleteTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _getTasksUseCase = getTasksUseCase;
        _getTask = getTask;
        _updateTaskUseCase = updateTaskUseCase;
        _deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost("api/Createtask")]
    public async Task<ActionResult<ToDo>> CreateTask([FromQuery] TaskRequest taskRequest,
        CancellationToken cancellationToken)
    {
        var result = await _createTaskUseCase.CreateTask(taskRequest, cancellationToken);
        return Ok(result);
    }

    [HttpGet("api/GetTasks")]
    public async Task<ActionResult<GetTaskResponse>> GetTasks(CancellationToken cancellationToken)
    {
        var (result, total) = await _getTasksUseCase.GetTasks(cancellationToken);
        return Ok(new GetTaskResponse(result, total));
    }

    [HttpGet("api/GetTask/{id:guid}")]
    public async Task<ActionResult<TaskInfo>> GetTask(Guid id, CancellationToken cancellationToken)
    {
        var result = await _getTask.GetTask(id, cancellationToken);
        return Ok(result);
    }

    [HttpPut("api/UpdateTask/{id:guid}")]
    public async Task<ActionResult<TaskInfo>> UpdateTask(Guid id,[FromQuery] TaskUpdateRequest taskRequest,
        CancellationToken cancellationToken)
    {
        var result = await _updateTaskUseCase.UpdateTask(id, taskRequest, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("api/DeleteTask/{id:guid}")]
    public async Task<ActionResult<string>> DeleteTask(Guid id, CancellationToken cancellationToken)
    {
        var result = await _deleteTaskUseCase.DeleteTask(id, cancellationToken);
        return Ok(result);
    }
}