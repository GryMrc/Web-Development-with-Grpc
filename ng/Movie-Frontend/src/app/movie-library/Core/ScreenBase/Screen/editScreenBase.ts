import { Directive } from "@angular/core";
import { SwalFirePopUp } from "src/app/movie-library/SwalFire/swalfire.popup";
import { CRUDService } from "../../CRUDService/CRUDService";
import { IDialogContainer } from "../../IDialogContainer/IDialogContainer";
import { ListScreenBase } from "./listScreenBase";

@Directive()
export abstract class EditScreenBase<T> {
    
    abstract container: IDialogContainer;
    mainScreen!: ListScreenBase<T>;

    constructor(public dataService: CRUDService<T>) {

    }

    abstract createForm():void;

    initiate(){
        this.createForm();
    }

    getId(model:any){
        return model.Id;
    }

    onSubmit(){
        switch(this.container.action){
            case 'Create':
                this.onCreate();
                break;
            case 'Update':
                this.onUpdate();
                break;
            case 'Delete':
                this.onDelete();
                break;
        } 
    }

    onCreate() {
        this.dataService.create(this.container.Item, 'Create').subscribe( 
            result  => {
                this.checkResult(result);
            },
            error => {
                SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
            });
    }

    onUpdate() {
        this.dataService.update(this.container.Item, 'Update').subscribe( 
            result  => {
                this.checkResult(result);
            },
            error => {
                SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
            });
    }

    onDelete() {
       this.dataService.delete(this.getId(this.container.Item), 'Delete').subscribe( 
        result  => {
            this.checkResult(result);
        },
        error => {
            SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
        });
    }

    checkResult(result:any){ // 2 serviceResponse class i oldgu icin any yaptim tipini ikisindede ayni seyi kontrol edecek no prob yani :D D:
        if(result.Success){
            SwalFirePopUp.swalFireSuccess(this.container.action);
            this.container.closeModal();
            this.mainScreen.refreshList();
        }
        else{
            if(result.Message){
                SwalFirePopUp.swalFireError(result.Message);
            }
        }
    }
    gRpcExceptionParser(error: string): string {
        error = error.replace(/"/g, "");
        const searchingValue = 'Detail=';
        const firstIndexofError = error.indexOf(searchingValue);
        const lastIndexofError = error.indexOf(')');
        return error.substring(firstIndexofError + searchingValue.length, lastIndexofError);
    }
}