import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ServiceVoidResponse } from "../../ServiceResponse/model/serviceResponse.model";
import { User } from "../model/user.model";

@Injectable()
export class UserService {

    constructor
        (private httpClient: HttpClient) {

    }

    login(user:User){
     return this.httpClient.post<ServiceVoidResponse>('http://localhost:5869/api/Authenticate/Login',user);
  }
    register(user:User){
        return this.httpClient.post<ServiceVoidResponse>('http://localhost:5869/api/Authenticate/Register',user);
    }
}