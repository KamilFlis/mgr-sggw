import { IsEmail, IsNotEmpty, MinLength, MaxLength } from "class-validator";

export class AuthUserDto {
    
    @IsEmail()
    email: string;

    @IsNotEmpty()
    @MinLength(5)
    @MaxLength(20)
    password: string;
}