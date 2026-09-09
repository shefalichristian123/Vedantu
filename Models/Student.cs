using System.ComponentModel.DataAnnotations;

namespace Vedantu.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required, StringLength(100)]
    public string FullName { get; set; } = "";

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = "";

    [Required, StringLength(20)]
    public string Phone { get; set; } = "";

    [Required]
    public string PasswordHash { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
