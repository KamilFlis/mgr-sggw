package com.sggw.jwttokenauthdemo.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class CityDTO {
    
    private String name;

    private CountryDTO country;
    
}
