import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../model/user.model";

@Injectable()
export class UserService {

    constructor
        (private httpClient: HttpClient) {

    }


    login(user:User){
        this.httpClient.post('http://localhost:5869/api/Authenticate/Register',user).subscribe(result => {
            console.log(result);
        })
    }
}