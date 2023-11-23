import { Injectable } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';

@Injectable()
export class HealthCheckService {

    constructor(private configService: ConfigService) {}

    healthCheck() {
        return `${this.configService.get<string>("profile.message")} is live`;
    }
}
