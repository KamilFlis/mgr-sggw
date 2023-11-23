package com.sggw.jwttokenauthdemo.service;

import org.springframework.core.env.Environment;
import org.springframework.stereotype.Service;

import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Service
public class HealthCheckService {
    
    private final Environment environment;

    public String healthCheck() {
        return environment.getProperty("profile.message") + " is live";
    }
}
