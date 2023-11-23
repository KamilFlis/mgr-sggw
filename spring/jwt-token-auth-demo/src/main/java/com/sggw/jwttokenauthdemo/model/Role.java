package com.sggw.jwttokenauthdemo.model;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.Collection;

@Entity(name = "roles")
@Setter
@Getter
@NoArgsConstructor
public class Role {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;

    @ManyToMany
    @JoinTable(
            name = "roles_privileges",
            joinColumns = @JoinColumn(
                name = "role_id", referencedColumnName = "id"
            ),
            inverseJoinColumns = @JoinColumn(
                name = "privilege_id", referencedColumnName = "id"
            )
    )
    private Collection<Privilege> privileges;

    public Role(String name) {
        this.name = name;
    }

}
