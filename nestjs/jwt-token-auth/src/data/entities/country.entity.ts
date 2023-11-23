import { Exclude } from "class-transformer";
import { Column, Entity, PrimaryGeneratedColumn } from "typeorm";

@Entity("countries")
export class Country {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    name: string;

    constructor(partial: Partial<Country>) {
        Object.assign(this, partial);
    }
}