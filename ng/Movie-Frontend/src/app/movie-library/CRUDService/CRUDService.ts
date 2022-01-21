import { HttpClient, HttpParams } from "@angular/common/http";
import { Router } from "@angular/router";
import { ServiceDataResponse, ServiceVoidResponse } from "../ServiceResponse/model/serviceResponse.model";

export class CRUDService<T>{

baseRoute: string = 'http://localhost:5869/api';
dataList: T[] = [];
constructor(public httpClient: HttpClient, public router:Router,x : new () => T) {
    //this.baseRoute = this.baseRoute + router.url + '/'; router.url ile kullaniyordum ama model ismi ile degistirdim
    this.baseRoute = this.baseRoute + '/' + x.name + '/';
}

create(model?:T, action = 'Create'){
    return this.httpClient.post<ServiceDataResponse>(this.baseRoute + action , model);
        //this.checkResult(result)
    // error => {
    //     console.log(error);
        
    //     SwalFirePopUp.swalFireError(error.message);
    // });

    // this.httpClient.get<ServiceDataResponse>(this.baseRoute + 'Read',{
    //     observe: 'body',
    //     responseType: 'json',
    //     params: new HttpParams()
    //         .set('Id', '3')
    // }).subscribe(result => {
    //     this.checkResult(result);
    // },
    // error => {
    //     console.log(error);
        
    //     SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
    //}
   
}

update(model?:T, action = 'Update'){
    return this.httpClient.put<ServiceVoidResponse>(this.baseRoute + action, model);
}

delete(Id: string, action = 'Delete'){
    return this.httpClient.delete<ServiceVoidResponse>(this.baseRoute + action,{
                observe: 'body',
                responseType: 'json',
                params: new HttpParams()
                    .set('Id', Id)
            })
}

list(){
    this.httpClient.get<any>(this.baseRoute + 'List').subscribe(result => {
        this.dataList = result.Data;
    });
}

}