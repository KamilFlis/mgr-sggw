import { Module } from "@nestjs/common";
import { ConfigModule, ConfigService } from "@nestjs/config";
import { TypeOrmModule } from '@nestjs/typeorm';

@Module({
  imports: [
    ConfigModule.forRoot(),
    TypeOrmModule.forRootAsync({
      imports: [ConfigModule],
      useFactory: (configService: ConfigService) => ({
        type: 'postgres',
        host: configService.get("database.host"),
        port: 5432,
        username: configService.get("database.username"),
        password: configService.get("database.password"),
        database: configService.get("database.serviceName"),
        autoLoadEntities: true,
        // synchronize: true,
        // extra: {
        //   ssl: true
        // }
      }),
      inject: [ConfigService],
    })
  ]
})
export class DatabaseModule {

}