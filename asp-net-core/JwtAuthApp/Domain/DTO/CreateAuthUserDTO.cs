using System.ComponentModel.DataAnnotations;

namespace JwtAuthApp.Domain.DTO;

public class CreateAuthUserDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string Password { get; set; }
    
}