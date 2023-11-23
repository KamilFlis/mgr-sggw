import { Column, Entity, JoinTable, ManyToMany, PrimaryGeneratedColumn } from "typeorm";
import { Privilege } from "./privilege.entity";
import { Exclude, Transform } from "class-transformer";

@Entity("roles")
export class Role {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    name: string;

    @ManyToMany(() => Privilege)
    @JoinTable({
        name: "roles_privileges",
        joinColumn: {
            name: "role_id",
            referencedColumnName: "id"
        },
        inverseJoinColumn: {
            name: "privilege_id",
            referencedColumnName: "id"
        },
    })
    privileges?: Privilege[];

    constructor(partial: Partial<Role>) {
        Object.assign(this, partial);
    }

}