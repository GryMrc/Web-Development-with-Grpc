import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CRUDService } from "../../CRUDService/CRUDService";
import { ServiceDataResponse, ServiceVoidResponse} from "../../ServiceResponse/model/serviceResponse.model";
import { Privilege } from "../model/privilege.model";
@Injectable()
export class PrivilegeService extends CRUDService<Privilege>{
    // some operations
    constructor
        (public httpClient: HttpClient,
         public router: Router) {
            super(httpClient,router,Privilege)
    }
}