import { ClassSerializerInterceptor, Controller, Get, Request, UseGuards, UseInterceptors } from '@nestjs/common';
import { UsersService } from './users.service';
import { Roles } from 'src/auth/roles.decorator';
import { JwtAuthGuard } from 'src/auth/guards/jwt-auth.guard';
import { RolesGuard } from 'src/auth/guards/roles.guard';

@UseGuards(JwtAuthGuard, RolesGuard)
@Controller('/api/users')
export class UsersController {

    constructor(private readonly usersService: UsersService) {}

    @Get()
    @Roles("ROLE_ADMIN")
    @UseInterceptors(ClassSerializerInterceptor)
    findAll() {
        return this.usersService.findAll();
    }
}
