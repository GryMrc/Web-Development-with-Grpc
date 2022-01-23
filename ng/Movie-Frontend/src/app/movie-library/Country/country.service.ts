import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CRUDService } from "../Core/CRUDService/CRUDService";
import { Country } from "./country.model";

@Injectable()
export class CountryService extends CRUDService<Country>{

constructor(public httpClient: HttpClient,
    public router: Router) {
    super(httpClient,router);
    }
}