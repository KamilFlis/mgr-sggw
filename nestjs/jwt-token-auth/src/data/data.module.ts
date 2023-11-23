import { Module } from '@nestjs/common';
import { DataService } from './data.service';
import { DataController } from './data.controller';
import { Data } from './entities/data.entity';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Member } from './entities/member.entity';
import { City } from './entities/city.entity';
import { Address } from './entities/address.entity';
import { Country } from './entities/country.entity';

@Module({
  imports: [TypeOrmModule.forFeature([Data, Member, Address, City, Country])],
  providers: [DataService],
  controllers: [DataController]
})
export class DataModule {}
