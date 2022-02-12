import { Component, Injectable, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';

@Component({
  selector: 'app-edit-screen-base',
  templateUrl: './edit-screen-base.component.html',
  styleUrls: ['./edit-screen-base.component.css']
})

@Injectable()
export class EditScreenBaseComponent<T> implements OnInit {

  Item: any;
  title: string = '';
  formGroup!: FormGroup;
  action: string = '';
  bsModalRef!: BsModalRef;
  parent: any;
  @ViewChild('modal') modal!: TemplateRef<any>;

  constructor(
    public modalService: BsModalService) {
}

  ngOnInit(): void {
  }

getId(model:any){
    return model.Id;
}

onSubmit():void{
    Object.assign(this.Item, this.formGroup.value);
    switch(this.action){
        case "Create": 
            this.parent.onCreate(this.Item).subscribe( (result: any) => {
                this.checkResult(result);
            },
            (error: any) => {
                SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
            }); 
            break; // create delete update icin Enum yazilabilir.
        case "Update": 
            this.parent.onUpdate(this.Item).subscribe( (result: any) => {
                this.checkResult(result);
            },
            (error: any) => {
                SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
            }); 
            break;
        case "Delete": 
            this.parent.onDelete(this.Item.Id).subscribe( (result: any) => {
                this.checkResult(result);
            },
            (error: any) => {
                SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
            });
            break;
    }
}

show(){
    Object.assign(this.formGroup.value, this.Item);
    this.bsModalRef = this.modalService.show(this.modal);
}

checkResult(result:any){ // 2 serviceResponse class i oldgu icin any yaptim tipini ikisindede ayni seyi kontrol edecek no prob yani :D D:
    if(result.Success){
        SwalFirePopUp.swalFireSuccess(this.action);
        this.closeModal();
        this.parent.listAll();
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

closeModal() {
    this.bsModalRef?.hide();
  }
}
