using System.ComponentModel.DataAnnotations;

namespace Domain.Requests;

public class TaskRequest
{
    [Required, MaxLength(25)]
    public string Title { get; set; }
    public string? Description { get; set; }
}