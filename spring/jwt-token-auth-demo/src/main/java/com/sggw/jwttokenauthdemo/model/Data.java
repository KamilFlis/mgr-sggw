package com.sggw.jwttokenauthdemo.model;

import java.util.Collection;

import jakarta.persistence.Entity;
import jakarta.persistence.FetchType;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.JoinTable;
import jakarta.persistence.ManyToMany;
import jakarta.persistence.OneToMany;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity(name = "data")
@Getter
@Setter
@NoArgsConstructor
public class Data {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;

    private String surname;

    private String phoneNumber;

    private int integerNumber;

    private double decimalNumber;

    @ManyToMany(fetch = FetchType.EAGER)
    @JoinTable(
            name = "data_addresses",
            joinColumns = @JoinColumn(
                    name = "data_id", referencedColumnName = "id"),
            inverseJoinColumns = @JoinColumn(
                    name = "address_id", referencedColumnName = "id"))
    private Collection<Address> addresses;

    @OneToMany
    @JoinColumn(name = "data_id")
    private Collection<Member> members;


}
