import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable} from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { BsModalRef } from "ngx-bootstrap/modal";
import { ServiceDataResponse, ServiceVoidResponse } from "../ServiceResponse/model/serviceResponse.model";
import { SwalFirePopUp } from "../SwalFire/swalfire.popup";

@Injectable()
export class CRUDLService<T>{

    dataList: T [] = [];
    action: string = '';
    currentItem: T | undefined;
    title: string = '';
    formGroup: FormGroup | undefined;
    baseRoute: string = 'http://localhost:5869/api';
    /**
     *
     */
    constructor(public httpClient: HttpClient,
        public router:Router,
        public bsModalRef: BsModalRef) {
            this.baseRoute = this.baseRoute + router.url + '/';
            console.log(this.baseRoute);
            
    }

    getId(model:any){
        return model.Id;
    }

    onSubmit(){
        this.currentItem = Object.assign(this.currentItem, this.formGroup?.value);
        console.log(this.currentItem);
        
        switch(this.action){
            case "Create": this.create(); break; // create delete update icin Enum yazilabilir.
            case "Update": this.update(); break;
            case "Delete": this.delete(); break;
        }

    }
    create() {
        this.httpClient.post<ServiceDataResponse>(this.baseRoute + this.action, this.currentItem).subscribe(result => {
            this.checkResult(result);
        },
        error => {
            SwalFirePopUp.swalFireError(error.message);
        });
    }

    update(){
        this.httpClient.put<ServiceVoidResponse>(this.baseRoute + this.action, this.currentItem).subscribe(result => {
           this.checkResult(result);
        },
        error => {
            SwalFirePopUp.swalFireError(error.message);
        });
    }

    delete(){
        this.httpClient.delete<ServiceVoidResponse>(this.baseRoute + this.action,{
            observe: 'body',
            responseType: 'json',
            params: new HttpParams()
                .set('Id', this.getId(this.currentItem))
        }).subscribe(result => {
            this.checkResult(result);
        },
        error => {
            SwalFirePopUp.swalFireError(error.message);
        });
    }

    checkResult(result:any){ // 2 serviceResponse class i oldgu icin any yaptim tipini ikisindede ayni seyi kontrol edecek no prob yani :D D:
        if(result.Success){
            SwalFirePopUp.swalFireSuccess(this.action);
            this.closeModal();
        }
        else{
            if(result.Message){
                SwalFirePopUp.swalFireError(result.Message);
            }
        }
    }
    
    closeModal() {
        this.bsModalRef.hide();
      }

      loggingIdentity(arg?: any): any {
        console.log(arg?.Id); // Now we know it has a .length property, so no more error
      }
}