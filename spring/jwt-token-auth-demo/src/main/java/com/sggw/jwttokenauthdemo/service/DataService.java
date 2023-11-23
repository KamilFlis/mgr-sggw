package com.sggw.jwttokenauthdemo.service;

import com.sggw.jwttokenauthdemo.model.Data;
import com.sggw.jwttokenauthdemo.repository.DataRepository;

import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;

import java.util.List;

@RequiredArgsConstructor
@Service
public class DataService {

    private final DataRepository dataRepository;

    public List<Data> getData() {
        return this.dataRepository.findAll();
    }

}
