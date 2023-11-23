package com.sggw.jwttokenauthdemo.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.sggw.jwttokenauthdemo.model.Address;

@Repository
public interface AddressRepository extends JpaRepository<Address, Long> {
    
}
