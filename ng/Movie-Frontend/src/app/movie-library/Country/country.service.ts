import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CRUDService } from "../Core/CRUDService/CRUDService";
import { Country } from "./country.model";

@Injectable()
export class CountryService extends CRUDService<Country>{

constructor(public httpClient: HttpClient) {
    super(httpClient,'Country/Country');
    }
}