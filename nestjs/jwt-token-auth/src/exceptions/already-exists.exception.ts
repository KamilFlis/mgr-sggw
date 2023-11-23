import { HttpException, HttpStatus } from "@nestjs/common";


export class AlreadyExistsException extends HttpException {
    
    message: string;
    
    constructor(message: string) {
        super(message, HttpStatus.BAD_REQUEST);
        this.message = message;
    }
}