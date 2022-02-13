import { Country } from "../../Country/country.model";

export class Person{
    Id: number = 0;
    Name: string = '';
    Age: number = 0;
    Gender = '';
    CountryId: number = 0;
    Country!: Country;
}