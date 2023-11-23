namespace JwtAuthApp.Domain.Models;

public class Role
{
    public long Id { get; set; }

    public string Name { get; set; }

    // public ICollection<User>? Users { get; set; }

    public ICollection<Privilege> Privileges { get; set; }
}