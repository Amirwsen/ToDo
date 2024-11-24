using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ToDo : BaseEntity
{
    [Required, MaxLength(25)]
    public string Title { get; set; }
    public string? Description { get; set; }
}