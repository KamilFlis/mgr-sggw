import { Exclude } from "class-transformer";
import { Column, PrimaryGeneratedColumn, Entity, JoinTable, ManyToMany, OneToMany, JoinColumn } from "typeorm";
import { Address } from "./address.entity";
import { Member } from "./member.entity";

@Entity("data")
export class Data {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    name: string;

    @Column()
    surname: string;

    @Column({ name: "phone_number" })
    phoneNumber: string;

    @Column({ name: "integer_number" })
    integerNumber: number;

    @Column({ name: "decimal_number" })
    decimalNumber: number;

    @ManyToMany(() => Address)
    @JoinTable({
        name: "data_addresses",
        joinColumn: {
            name: "data_id",
            referencedColumnName: "id"
        },
        inverseJoinColumn: {
            name: "address_id",
            referencedColumnName: "id"
        },
    })
    addresses?: Address[];

    @OneToMany(() => Member, (member) => member.data)
    members?: Member[];

    constructor(partial: Partial<Data>) {
        Object.assign(this, partial);
    }

}
