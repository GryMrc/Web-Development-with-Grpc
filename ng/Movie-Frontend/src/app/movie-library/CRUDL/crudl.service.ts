import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class CRUDLService<T>{

    dataList: T [] = [];
    baseRoute: string = 'http://localhost:5869/api';
    /**
     *
     */
    constructor(public httpClient: HttpClient,
        public router:Router) {
            this.baseRoute = this.baseRoute + router.url + '/';
            console.log(this.baseRoute);
            
    }

    create(model: T, action = 'Create') {
        return this.httpClient.post<T>(this.baseRoute + action, model).subscribe(result => {
            console.log(result);
            
        });
    }
}