package com.sggw.jwttokenauthdemo.service;

import com.sggw.jwttokenauthdemo.model.Privilege;
import com.sggw.jwttokenauthdemo.model.User;
import com.sggw.jwttokenauthdemo.repository.UserRepository;

import com.sggw.jwttokenauthdemo.model.Role;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

@Service
public class MyUserDetailsService implements UserDetailsService {

    @Autowired
    private UserRepository userRepository;

    @Override
    @Transactional
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        User userEntity = userRepository.findByEmail(username);
        if(userEntity == null) {
            throw new UsernameNotFoundException(username);
        }

        return org.springframework.security.core.userdetails.User
                .withUsername(userEntity.getEmail())
                .password(userEntity.getPassword())
                .accountExpired(false)
                .accountLocked(false)
                .authorities(getAuthorities(userEntity.getRoles()))
                .credentialsExpired(false)
                .disabled(false)
                .build();
    }

    private Collection<? extends GrantedAuthority> getAuthorities(Collection<Role> roles) {
        return this.getGrantedAuthorities(getPrivileges(roles));
    }

    private List<String> getPrivileges(Collection<Role> roles) {
        List<String> privileges = new ArrayList<>();
        List<Privilege> collection = new ArrayList<>();
        for(Role role: roles) {
            privileges.add(role.getName());
            collection.addAll(role.getPrivileges());
        }
        for(Privilege item: collection) {
            privileges.add(item.getName());
        }
        return privileges;
    }

    private List<GrantedAuthority> getGrantedAuthorities(List<String> privileges) {
        List<GrantedAuthority> authorities = new ArrayList<>();
        for(String privilege: privileges) {
            authorities.add(new SimpleGrantedAuthority(privilege));
        }
        return authorities;
    }
}
