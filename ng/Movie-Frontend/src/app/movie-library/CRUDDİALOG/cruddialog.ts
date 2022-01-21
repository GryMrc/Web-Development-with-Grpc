import { Injectable} from "@angular/core";
import { FormGroup } from "@angular/forms";
import { BsModalRef } from "ngx-bootstrap/modal";
import { CRUDService } from "../CRUDService/CRUDService";
import { SwalFirePopUp } from "../SwalFire/swalfire.popup";

@Injectable()
export class CRUDDİALOG<T>{
    action: string = '';
    currentItem: T | undefined;
    title: string = '';
    formGroup: FormGroup | undefined;
    /**
     *
     */
    constructor(public bsModalRef: BsModalRef,
        public dataService: CRUDService<T>) {
    }

    getId(model:any){
        return model.Id;
    }

    onSubmit(){
        this.currentItem = Object.assign(this.currentItem, this.formGroup?.value);
        switch(this.action){
            case "Create": this.onCreate(); break; // create delete update icin Enum yazilabilir.
            case "Update": this.onUpdate(); break;
            case "Delete": this.onDelete(); break;
        }

    }
   
    onCreate(){
        this.dataService.create(this.currentItem ,'Create').subscribe( result => {
           this.checkResult(result);
        });
    }
    
    onUpdate(){
        this.dataService.update(this.currentItem,'Update').subscribe( result => {
           this.checkResult(result);
        },
        error => {
            SwalFirePopUp.swalFireError(error.message);
        });
    }

    onDelete(){
        this.dataService.delete(this.getId(this.currentItem),'Delete').subscribe(result => {
            this.checkResult(result);
        },
        error => {
            SwalFirePopUp.swalFireError(error.message);
        });
    }

    checkResult(result:any){ // 2 serviceResponse class i oldgu icin any yaptim tipini ikisindede ayni seyi kontrol edecek no prob yani :D D:
        if(result.Success){
            this.dataService.list();
            SwalFirePopUp.swalFireSuccess(this.action);
            this.closeModal();
        }
        else{
            if(result.Message){
                SwalFirePopUp.swalFireError(result.Message);
            }
        }
    }

    gRpcExceptionParser(error: string): string{
        error = error.replace(/"/g, "");
        const searchingValue = 'Detail=';
        const firstIndexofError = error.indexOf(searchingValue);
        const lastIndexofError = error.indexOf(')');
        return error.substring(firstIndexofError + searchingValue.length, lastIndexofError);
    }
    
    closeModal() {
        this.bsModalRef.hide();
      }
}