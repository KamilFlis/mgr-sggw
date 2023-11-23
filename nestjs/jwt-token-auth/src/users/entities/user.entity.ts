import { Column, Entity, JoinTable, ManyToMany, PrimaryGeneratedColumn } from "typeorm";
import { Role } from "./role.entity";
import { Exclude } from "class-transformer";

@Entity("users")
export class User {

    @Exclude()
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    email: string;

    @Exclude()
    @Column()
    password: string;

    @ManyToMany(() => Role)
    @JoinTable({
        name: "users_roles",
        joinColumn: {
            name: "user_id",
            referencedColumnName: "id"
        },
        inverseJoinColumn: {
            name: "role_id",
            referencedColumnName: "id"
        },
    })
    roles?: Role[];
    
    constructor(partial: Partial<User>) {
        Object.assign(this, partial);
    }

}