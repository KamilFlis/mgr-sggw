import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
import { LocalStrategy } from './strategies/local.strategy';
import { AuthController } from './auth.controller';
import { AuthService } from './auth.service';
import { User } from '../users/entities/user.entity';
import { Role } from '../users/entities/role.entity';
import { jwtConstants } from './constants';
import { JwtStrategy } from './strategies/jwt-strategy';
import { UsersService } from '../users/users.service';
import { RolesService } from '../users/roles.service';

@Module({
  imports: [
    PassportModule, 
    TypeOrmModule.forFeature([User, Role]),
    JwtModule.register({
      secret: jwtConstants.secret,
      signOptions: { expiresIn: jwtConstants.expiration_time },
    }),
  ],
  controllers: [AuthController],
  providers: [AuthService, LocalStrategy, JwtStrategy, UsersService, RolesService],
  exports: [AuthService],
})
export class AuthModule {}
