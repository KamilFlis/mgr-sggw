package com.sggw.jwttokenauthdemo.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.sggw.jwttokenauthdemo.model.Country;

@Repository
public interface CountryRepository extends JpaRepository<Country, Long> {
    
}
