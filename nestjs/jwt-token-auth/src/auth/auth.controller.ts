import { Body, Controller, Post, HttpCode, HttpStatus, UseGuards, UsePipes, ValidationPipe } from '@nestjs/common';
import { AuthService } from './auth.service';
import { AuthUserDto } from './dto/auth-user.dto';
import { LocalAuthGuard } from './guards/local-auth.guard';


@Controller('/api')
export class AuthController {

    constructor(private readonly authService: AuthService) {}

    @UseGuards(LocalAuthGuard)
    @Post("/login")
    async login(@Body() authUserDto: AuthUserDto) {
        const user = await this.authService.validateUser(authUserDto.email, authUserDto.password);
        return this.authService.login(user);
    }

    @UsePipes(new ValidationPipe({ transform: true }))
    @HttpCode(HttpStatus.CREATED)
    @Post("/register")
    async register(@Body() authUserDto: AuthUserDto) {
        return this.authService.register(authUserDto.email, authUserDto.password);
    }

}
