package com.sggw.jwttokenauthdemo.dto.mapper;

import java.util.List;

import org.mapstruct.Mapper;

import com.sggw.jwttokenauthdemo.dto.*;
import com.sggw.jwttokenauthdemo.model.*;

@Mapper(componentModel = "spring")
public interface MapStructMapper {
    
    List<UserDTO> usersToUserDTO(List<User> users);

    List<RoleDTO> rolesToRoleDTO(List<Role> roles);

    List<PrivilegeDTO> privilegesToPrivilegeDTO(List<Privilege> privileges);

    List<DataDTO> dataToDataDTO(List<Data> data);

    MemberDTO memberToMemberDTO(Member member);

    List<MemberDTO> membersToMemberDTO(List<Member> members);

    AddressDTO addressToAddressDTO(Address address);

    List<AddressDTO> addressesToAddressDTO(List<Address> addresses);

    CityDTO cityToCityDTO(City city);

    CountryDTO countryToCountryDTO(Country country);

}
