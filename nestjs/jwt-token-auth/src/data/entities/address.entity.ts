import { Exclude } from "class-transformer";
import { Column, Entity, JoinColumn, ManyToOne, PrimaryGeneratedColumn } from "typeorm";
import { City } from "./city.entity";

@Entity("addresses")
export class Address {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    street: string;

    @ManyToOne(() => City)
    @JoinColumn([{ name: "city_id", referencedColumnName: "id" }])
    city: City;

    constructor(partial: Partial<Address>) {
        Object.assign(this, partial);
    }
}