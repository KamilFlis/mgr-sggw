package com.sggw.jwttokenauthdemo.dto;

import java.util.List;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class UserDTO {
    
    private String email;
    private List<RoleDTO> roles;

}
