namespace Domain.Responses;

public record TaskInfo(Guid Id, string Title, string Description, DateTime CreatedAt);