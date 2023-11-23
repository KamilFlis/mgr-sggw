import { Injectable } from '@nestjs/common';
import { User } from './entities/user.entity';
import { Repository } from 'typeorm';
import { InjectRepository } from '@nestjs/typeorm';
import { Role } from './entities/role.entity';

@Injectable()
export class UsersService {

    constructor(@InjectRepository(User) private readonly userRepository: Repository<User>) {}

    async findAll(): Promise<User[]> {
        return this.userRepository.find({
            relations: ["roles", "roles.privileges"]
        });
    }

    async findOne(email: string): Promise<User> {
        return this.userRepository.findOne({
            where: {
                email: email,
            },
            relations: {
                roles: true
            }
        });
    }

    async save(email: string, passwordHash: string, roles: Role[]): Promise<User> {
        const user: User = this.userRepository.create({
            email: email,
            password: passwordHash,
            roles: roles,
        });

        return this.userRepository.save(user);
    }

}
