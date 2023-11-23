import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { HealthCheckService } from './health-check.service';
import { HealthCheckController } from './health-check.controller';

@Module({
  imports: [ConfigModule],
  providers: [HealthCheckService],
  controllers: [HealthCheckController]
})
export class HealthCheckModule {}
