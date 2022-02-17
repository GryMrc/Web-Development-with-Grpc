import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CRUDService } from "../../Core/CRUDService/CRUDService";
import { Director } from "../model/director.model";

@Injectable()
export class DirectorService extends CRUDService<Director>{

constructor(public httpClient: HttpClient) {
    super(httpClient,'Crew/Director');
    }
}