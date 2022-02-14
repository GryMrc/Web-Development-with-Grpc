import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CRUDService } from "../../Core/CRUDService/CRUDService";
import { Director } from "../model/director.model";

@Injectable()
export class DirectorService extends CRUDService<Director>{

constructor(public httpClient: HttpClient, public router: Router) {
    super(httpClient,router);
    }
}