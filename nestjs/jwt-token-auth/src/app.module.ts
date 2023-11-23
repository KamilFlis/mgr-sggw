import { Module } from '@nestjs/common';
import { ConfigModule, ConfigService } from '@nestjs/config';
import { join } from 'path';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { HealthCheckModule } from './health-check/health-check.module';
import { configuration } from '../config/configuration';
import { DatabaseModule } from './database/database.module';
import { DataModule } from './data/data.module';
import { AuthModule } from './auth/auth.module';
import { UsersModule } from './users/users.module';

const ENV = process.env.NODE_ENV;

@Module({
  imports: [
    ConfigModule.forRoot({
      envFilePath: join(`${process.cwd()}`, "config", !ENV ? ".env" : `${process.env.NODE_ENV}.env`),
      load: [configuration]
    }),
    DatabaseModule,
    HealthCheckModule,
    DataModule,
    AuthModule,
    UsersModule,
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
