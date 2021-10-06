import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ServiceResponse } from "../../ServiceResponse/model/serviceResponse.model";
import { Privilege } from "../model/privilege.model";
@Injectable()
export class PrivilegeService {
    // some operations


    constructor
        (private httpClient: HttpClient) {
    }


    create(privilege: Privilege) {
        return this.httpClient.post<ServiceResponse>('http://localhost:5869/api/Privilege/Create', privilege);
    }

    list() {
        return this.httpClient.get<Privilege[]>('http://localhost:5869/api/Privilege/List'); // donus tipi generic dataList olarak duzenlenecek
    }


}