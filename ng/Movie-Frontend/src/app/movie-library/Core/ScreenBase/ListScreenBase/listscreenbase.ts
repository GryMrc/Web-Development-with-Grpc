import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { CRUDService } from "../../CRUDService/CRUDService";

@Injectable()
export class ListScreenBase {
    pageSize = 10;
    pageable = true;
}