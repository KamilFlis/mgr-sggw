import { Exclude } from "class-transformer";
import { Column, Entity, JoinColumn, ManyToOne, PrimaryGeneratedColumn } from "typeorm";
import { Data } from "./data.entity";

@Entity("members")
export class Member {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    name: string;

    @Column()
    surname: string;

    @Exclude()
    @ManyToOne(() => Data, (data) => data.members)
    @JoinColumn([{ name: "data_id", referencedColumnName: "id" }])
    data: Data[];

    constructor(partial: Partial<Member>) {
        Object.assign(this, partial);
    }

}