import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { Data } from './entities/data.entity';

@Injectable()
export class DataService {

    constructor(@InjectRepository(Data) private readonly dataRepository: Repository<Data>) {}

    async findAll(): Promise<Data[]> {
        return await this.dataRepository.find({
            relations: ["members", "addresses", "addresses.city", "addresses.city.country"]
        });
    }
}
