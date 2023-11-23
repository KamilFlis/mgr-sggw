import { Controller, Get } from '@nestjs/common';
import { HealthCheckService } from './health-check.service';

@Controller('/api/health')
export class HealthCheckController {

    constructor(private readonly healthCheckService: HealthCheckService) {}

    @Get()
    healthCheck() {
        return this.healthCheckService.healthCheck();
    }
}
