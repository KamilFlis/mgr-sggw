package com.sggw.jwttokenauthdemo.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class AddressDTO {

    private String street;
    
    private CityDTO city;

}
