package com.sggw.jwttokenauthdemo.dto;

import java.util.List;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Pattern;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class DataDTO {
    
    private String name;

    private String surname;

    @NotBlank(message = "Invalid Phone number: Empty number")
    @NotNull(message = "Invalid Phone number: Number is NULL")
    @Pattern(regexp = "^\\d{10}$", message = "Invalid phone number")
    private String phoneNumber;

    private int integerNumber;

    private double decimalNumber;

    private List<AddressDTO> addresses;

    private List<MemberDTO> members;


}
