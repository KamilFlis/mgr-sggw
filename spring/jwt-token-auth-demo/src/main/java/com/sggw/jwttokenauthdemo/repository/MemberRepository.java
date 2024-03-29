package com.sggw.jwttokenauthdemo.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.sggw.jwttokenauthdemo.model.Member;

@Repository
public interface MemberRepository extends JpaRepository<Member, Long> {
    
}
