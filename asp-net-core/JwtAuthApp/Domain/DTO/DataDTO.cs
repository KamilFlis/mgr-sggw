using System.Collections.ObjectModel;

namespace JwtAuthApp.Domain.DTO;

public class DataDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public int IntegerNumber { get; set; }
    public double DecimalNumber { get; set; }
    public Collection<AddressDTO> Addresses { get; set; }
    public Collection<MemberDTO> Members { get; set; }

}