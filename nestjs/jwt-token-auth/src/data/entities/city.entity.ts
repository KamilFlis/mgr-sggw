import { Exclude } from "class-transformer";
import { Column, Entity, JoinColumn, ManyToOne, PrimaryGeneratedColumn } from "typeorm";
import { Country } from "./country.entity";

@Entity("cities")
export class City {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    name: string;

    @ManyToOne(() => Country)
    @JoinColumn([{ name: "country_id", referencedColumnName: "id" }])
    country: Country;

    constructor(partial: Partial<City>) {
        Object.assign(this, partial);
    }

}