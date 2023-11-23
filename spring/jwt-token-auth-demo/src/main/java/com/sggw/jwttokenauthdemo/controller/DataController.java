package com.sggw.jwttokenauthdemo.controller;

import com.sggw.jwttokenauthdemo.dto.DataDTO;
import com.sggw.jwttokenauthdemo.dto.mapper.MapStructMapper;
import com.sggw.jwttokenauthdemo.model.Data;
import com.sggw.jwttokenauthdemo.service.DataService;

import lombok.RequiredArgsConstructor;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RequiredArgsConstructor
@RestController()
@RequestMapping("/api/data/")
public class DataController {

    private final MapStructMapper mapper;

    private final DataService dataService;

    @GetMapping()
    public ResponseEntity<List<DataDTO>> getData() {
        
        List<Data> data = this.dataService.getData();
        List<DataDTO> dataDTO = mapper.dataToDataDTO(data);

        return new ResponseEntity<List<DataDTO>>(dataDTO, HttpStatus.OK);
    }


}
