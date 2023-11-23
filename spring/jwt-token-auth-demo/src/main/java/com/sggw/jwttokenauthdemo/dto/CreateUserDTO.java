package com.sggw.jwttokenauthdemo.dto;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
public class CreateUserDTO {
    
    @Email(message = "Invalid email")
    private String email;

    @NotBlank(message = "Invalid password: Empty password")
    @NotNull(message = "Invalid password: Password is NULL")
    @Size(min = 5, max = 30, message = "Invalid password: Must be of 5 - 20 characters")
    private String password;

}