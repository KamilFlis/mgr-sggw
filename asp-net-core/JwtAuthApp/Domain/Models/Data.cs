using System.Collections.ObjectModel;

namespace JwtAuthApp.Domain.Models;

public class Data
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? PhoneNumber { get; set; }

    public int IntegerNumber { get; set; }

    public double DecimalNumber { get; set; }

    public Collection<Address> Addresses { get; set; }

    public Collection<Member> Members { get; set; }

}