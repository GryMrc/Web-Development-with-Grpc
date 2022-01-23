import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CRUDService } from "../../Core/CRUDService/CRUDService";
import { Privilege } from "../model/privilege.model";
@Injectable()
export class PrivilegeService extends CRUDService<Privilege>{
    // some operations
    constructor
        (public httpClient: HttpClient,
         public router: Router) {
            super(httpClient,router)
    }
}