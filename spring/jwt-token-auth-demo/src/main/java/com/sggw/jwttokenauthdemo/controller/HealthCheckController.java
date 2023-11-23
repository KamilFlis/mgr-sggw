package com.sggw.jwttokenauthdemo.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.sggw.jwttokenauthdemo.service.HealthCheckService;

import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@RestController
@RequestMapping("/api/health")
public class HealthCheckController {
    
    private final HealthCheckService healthCheckService;

    @GetMapping()
    public ResponseEntity<String> healthCheck() { 
        String liveMessage = this.healthCheckService.healthCheck();
        return new ResponseEntity<String>(liveMessage, HttpStatus.OK);
    }
}