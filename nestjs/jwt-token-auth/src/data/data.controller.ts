import { Controller, Get, UseGuards, UseInterceptors, ClassSerializerInterceptor } from '@nestjs/common';
import { DataService } from './data.service';
import { JwtAuthGuard } from 'src/auth/guards/jwt-auth.guard';

@UseGuards(JwtAuthGuard)
@Controller('/api/data')
export class DataController {

    constructor(private readonly dataService: DataService) {}

    @Get()
    @UseInterceptors(ClassSerializerInterceptor)
    findAll() {
        return this.dataService.findAll();
    }
}
