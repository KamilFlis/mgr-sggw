package com.sggw.jwttokenauthdemo.config;

import com.sggw.jwttokenauthdemo.model.Privilege;
import com.sggw.jwttokenauthdemo.model.Role;
import com.sggw.jwttokenauthdemo.model.User;
import com.sggw.jwttokenauthdemo.repository.PrivilegeRepository;
import com.sggw.jwttokenauthdemo.repository.RoleRepository;
import com.sggw.jwttokenauthdemo.repository.UserRepository;
import jakarta.transaction.Transactional;
import lombok.RequiredArgsConstructor;

import org.springframework.context.ApplicationListener;
import org.springframework.context.event.ContextRefreshedEvent;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Component;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;

@RequiredArgsConstructor
@Component
public class SetupDataLoader implements ApplicationListener<ContextRefreshedEvent> {

    private boolean alreadySetup = false;

    private final UserRepository userRepository;

    private final RoleRepository roleRepository;

    private final PrivilegeRepository privilegeRepository;

    private final PasswordEncoder passwordEncoder;


    @Override
    @Transactional
    public void onApplicationEvent(ContextRefreshedEvent event) {

        Role checkRole = this.roleRepository.findByName("ROLE_ADMIN");
        if(checkRole != null) {
            this.alreadySetup = true;
        }

        if(this.alreadySetup) {
            return;
        }

        Privilege readPrivilege = this.createPrivilegeIfNotFound("READ_PRIVILEGE");
        Privilege writePrivilege = this.createPrivilegeIfNotFound("WRITE_PRIVILEGE");

        List<Privilege> adminPrivileges = Arrays.asList(readPrivilege, writePrivilege);
        this.createRoleIfNotFound("ROLE_ADMIN", adminPrivileges);
        this.createRoleIfNotFound("ROLE_USER", Arrays.asList(readPrivilege));

        Role adminRole = this.roleRepository.findByName("ROLE_ADMIN");

        String adminEmail = "Admin@admin.com";

        User adminUser = this.userRepository.findByEmail(adminEmail);
        if(adminUser != null) {
            this.alreadySetup = true;
            return;
        }

        User user = new User();
        user.setEmail(adminEmail);
        user.setPassword(this.passwordEncoder.encode("kamil"));
        user.setRoles(Arrays.asList(adminRole));
        this.userRepository.save(user);

        this.alreadySetup = true;
    }

    @Transactional
    private Privilege createPrivilegeIfNotFound(String name) {
        Privilege privilege = this.privilegeRepository.findByName(name);
        if(privilege == null) {
            privilege = new Privilege(name);
            this.privilegeRepository.save(privilege);
        }
        return privilege;
    }

    private Role createRoleIfNotFound(String name, Collection<Privilege> privileges) {
        Role role = this.roleRepository.findByName(name);
        if(role == null) {
            role = new Role(name);
            role.setPrivileges(privileges);
            this.roleRepository.save(role);
        }
        return role;
    }



}
