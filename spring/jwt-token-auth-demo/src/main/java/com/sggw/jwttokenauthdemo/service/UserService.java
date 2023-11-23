package com.sggw.jwttokenauthdemo.service;

import com.sggw.jwttokenauthdemo.exception.AlreadyExistsException;
import com.sggw.jwttokenauthdemo.model.User;
import com.sggw.jwttokenauthdemo.repository.RoleRepository;
import com.sggw.jwttokenauthdemo.repository.UserRepository;

import lombok.RequiredArgsConstructor;

import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.Arrays;
import java.util.List;

@RequiredArgsConstructor
@Service
public class UserService {

    private final UserRepository userRepository;

    private final RoleRepository roleRepository;

    private final PasswordEncoder passwordEncoder;

    public void register(@RequestBody User user) {
        User alreadyExists = this.userRepository.findByEmail(user.getEmail());
        if(alreadyExists != null) {
            throw new AlreadyExistsException("User with that email already exists");
        }

        user.setPassword(passwordEncoder.encode(user.getPassword()));
        user.setRoles(Arrays.asList(roleRepository.findByName("ROLE_USER")));
        this.userRepository.save(user);
        
    }

    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public List<User> findAll() {
        return this.userRepository.findAll();
    }


}
