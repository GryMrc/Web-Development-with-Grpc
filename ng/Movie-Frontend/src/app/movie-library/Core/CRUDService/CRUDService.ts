import { HttpClient, HttpParams } from "@angular/common/http";
import { Router } from "@angular/router";
import { ServiceDataResponse, ServiceVoidResponse } from "../../ServiceResponse/model/serviceResponse.model";

export abstract class CRUDService<T>{

baseRoute: string = 'http://localhost:5869/api/';
dataList: T[] = [];
completeList: T[] = [];
constructor(public httpClient: HttpClient, public module:string) {
    this.baseRoute = this.baseRoute + module + '/'; //router.url //ile kullaniyordum ama model ismi ile degistirdim
    //this.baseRoute = this.baseRoute + '/' + x.name + '/';
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

listAll(){
    this.httpClient.get<any>(this.baseRoute + 'ListAll').subscribe(result => {
        this.dataList = result.Data;
    });
}

list(listParams:any){
    this.httpClient.get<T[]>(this.baseRoute + 'List', {
        observe: 'body',
        responseType: 'json',
        params: new HttpParams()
        .set('pageSize',listParams.pageSize)
        .set('page', listParams.page)
    }).subscribe(result => {
        this.dataList = result;
    });
}

}