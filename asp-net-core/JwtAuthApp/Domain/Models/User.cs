namespace JwtAuthApp.Domain.Models;

public class User 
{
    public long Id { get; set; }

    // [Required]
    // [EmailAddress]
    public string Email { get; set; }

    // [Required]
    // [DataType(DataType.Password)]
    public string Password { get; set; }

    public ICollection<Role> Roles { get; set; }

}
