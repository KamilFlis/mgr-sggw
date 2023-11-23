namespace JwtAuthApp.Domain.Models;

public class City
{
    public long Id { get; set; }
    public string Name { get; set; }
    public Country? Country { get; set; }
}