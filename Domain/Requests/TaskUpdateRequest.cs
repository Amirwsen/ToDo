using System.ComponentModel.DataAnnotations;

namespace Domain.Requests;

public class TaskUpdateRequest
{
    [MaxLength(25)]
    public string? Title { get; set; }
    public string? Description { get; set; }
}