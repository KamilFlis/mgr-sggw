namespace JwtAuthApp.Domain.DTO;

public class UserDTO 
{
    public string Email { get; set; }
    public ICollection<RoleDTO> Roles { get; set; }
}