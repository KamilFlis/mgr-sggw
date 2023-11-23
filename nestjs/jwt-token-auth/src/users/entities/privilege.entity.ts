import { Exclude } from "class-transformer";
import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";


@Entity("privileges")
export class Privilege {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    name: string;

    constructor(partial: Partial<Privilege>) {
        Object.assign(this, partial);
    }

}