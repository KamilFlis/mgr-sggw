using AutoMapper;
using JwtAuthApp.Domain.DTO;
using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Domain.Mapper;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
        CreateMap<Privilege, PrivilegeDTO>().ReverseMap();
        CreateMap<Data, DataDTO>().ReverseMap();
        CreateMap<Member, MemberDTO>().ReverseMap();
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<City, CityDTO>().ReverseMap();
        CreateMap<Country, CountryDTO>().ReverseMap();
    }
}