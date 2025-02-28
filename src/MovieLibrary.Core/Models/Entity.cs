using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Core.Models;

public class Entity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
}