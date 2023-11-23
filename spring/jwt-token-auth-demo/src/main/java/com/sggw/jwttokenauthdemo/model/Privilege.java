package com.sggw.jwttokenauthdemo.model;

import jakarta.persistence.*;
import lombok.*;

@Entity(name = "privileges")
@Setter
@Getter
@NoArgsConstructor
public class Privilege {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    private String name;

    public Privilege(String name) {
        this.name = name;
    }

}
