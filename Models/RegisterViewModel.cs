using System.ComponentModel.DataAnnotations;

namespace Vedantu.Models;

public class RegisterViewModel
{
    [Required, StringLength(100)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = "";

    [Required, EmailAddress]
    public string Email { get; set; } = "";

    [Required, StringLength(20)]
    public string Phone { get; set; } = "";

    [Required, MinLength(6), DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required, Compare(nameof(Password)), DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = "";
}
