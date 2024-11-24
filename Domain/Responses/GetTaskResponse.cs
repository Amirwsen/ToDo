namespace Domain.Responses;

public sealed record GetTaskResponse
(
    List<TaskInfo> taskInfos,
    int total
);