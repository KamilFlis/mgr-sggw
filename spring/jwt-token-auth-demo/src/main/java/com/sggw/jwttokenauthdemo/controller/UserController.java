package com.sggw.jwttokenauthdemo.controller;

import com.sggw.jwttokenauthdemo.dto.CreateUserDTO;
import com.sggw.jwttokenauthdemo.dto.mapper.MapStructMapper;
import com.sggw.jwttokenauthdemo.exception.AlreadyExistsException;
import com.sggw.jwttokenauthdemo.model.User;
import com.sggw.jwttokenauthdemo.service.UserService;

import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RequiredArgsConstructor
@RestController()
@RequestMapping("/api/")
public class UserController {

    private final MapStructMapper mapper;

    private final UserService userService;

    @PostMapping("register/")
    public ResponseEntity<String> register(@RequestBody @Valid CreateUserDTO userDTO) {
        try {
            User user = new User();
            user.setEmail(userDTO.getEmail());
            user.setPassword(userDTO.getPassword());
            this.userService.register(user);
        } catch(AlreadyExistsException e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.BAD_REQUEST);
        } catch(Exception e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR);
        }

        return new ResponseEntity<>("User successfully created.", HttpStatus.CREATED);
    }

    @GetMapping("users/")
    public ResponseEntity<?> findAll() {
        List<User> users;
        try {
            users = this.userService.findAll();
        } catch (Exception e) {
            return new ResponseEntity<>(e.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR);
        }

        return new ResponseEntity<>(mapper.usersToUserDTO(users), HttpStatus.OK);

    }
}
