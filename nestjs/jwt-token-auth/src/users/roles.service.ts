import { Injectable } from '@nestjs/common';
import { Role } from './entities/role.entity';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';

@Injectable()
export class RolesService {

    constructor(@InjectRepository(Role) private readonly roleRepository: Repository<Role>) {}

    async findOne(name: string) {
        return this.roleRepository.findOne({
            where: {
                name: name
            },
        });
    }

}