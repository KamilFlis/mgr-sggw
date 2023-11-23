namespace JwtAuthApp.Domain.DTO;

public class RoleDTO
{
    public string Name { get; set; }
    public ICollection<PrivilegeDTO> Privileges { get; set; }
}