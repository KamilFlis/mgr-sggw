import { Injectable } from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';

import * as bcrypt from 'bcrypt';

import { AlreadyExistsException } from 'src/exceptions/already-exists.exception';
import { User } from 'src/users/entities/user.entity';
import { UsersService } from 'src/users/users.service';
import { Role } from 'src/users/entities/role.entity';
import { RolesService } from 'src/users/roles.service';

@Injectable()
export class AuthService {

    constructor(
        private usersService: UsersService,
        private rolesService: RolesService,
        private jwtService: JwtService
    ) {}

    async validateUser(email: string, password: string): Promise<any> {
        let user: User;
        user = await this.usersService.findOne(email);
        if(!user) {
            return null;
        }

        const isPasswordMatch = await bcrypt.compare(password, user.password)
        if(!isPasswordMatch) {
            return null;
        }

        return user;
    }

    async login(user: User) {
        const payload = { username: user.email, sub: user.id, roles: user.roles };
        return {
            access_token: this.jwtService.sign(payload),
        };
    }

    async register(email: string, password: string) {
        let user: User = await this.usersService.findOne(email);
        
        if(user) {
            throw new AlreadyExistsException("User with that email already exists");
        }

        const salt = await bcrypt.genSalt();
        const hash = await bcrypt.hash(password, salt);

        const userRole: Role = await this.rolesService.findOne("ROLE_USER");

        await this.usersService.save(email, hash, [userRole]);

        return "User successfully created";
    }


}
