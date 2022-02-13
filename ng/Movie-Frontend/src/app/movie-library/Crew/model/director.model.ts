import { Person } from "./person.model";

export class Director{
   Id!: number;
   Person: Person = new Person();
   UserId: number = 0;
}