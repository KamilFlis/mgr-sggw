import { Module } from '@nestjs/common';
import { UsersService } from './users.service';
import { UsersController } from './users.controller';
import { User } from './entities/user.entity';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Role } from './entities/role.entity';
import { Privilege } from './entities/privilege.entity';

@Module({
  imports: [TypeOrmModule.forFeature([User, Role, Privilege])],
  providers: [UsersService],
  controllers: [UsersController]
})
export class UsersModule {}
