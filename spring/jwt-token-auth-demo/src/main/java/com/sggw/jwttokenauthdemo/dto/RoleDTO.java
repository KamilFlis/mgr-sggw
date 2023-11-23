package com.sggw.jwttokenauthdemo.dto;

import java.util.List;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class RoleDTO {

    private String name;
    private List<PrivilegeDTO> privileges;

}
