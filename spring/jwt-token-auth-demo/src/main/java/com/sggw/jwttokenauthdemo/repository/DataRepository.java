package com.sggw.jwttokenauthdemo.repository;

import com.sggw.jwttokenauthdemo.model.Data;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DataRepository extends JpaRepository<Data, Long> { }
