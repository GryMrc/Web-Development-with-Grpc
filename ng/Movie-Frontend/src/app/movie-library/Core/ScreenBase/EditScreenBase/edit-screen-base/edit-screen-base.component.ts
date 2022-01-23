import { Component, ContentChild, Injectable, Input, OnInit, TemplateRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
import { CRUDService } from '../../../CRUDService/CRUDService';

@Component({
  selector: 'app-edit-screen-base',
  templateUrl: './edit-screen-base.component.html',
  styleUrls: ['./edit-screen-base.component.css']
})

@Injectable()
export class EditScreenBaseComponent<T> implements OnInit {

  @Input() Item: any;
  @Input() title: string = '';
  @Input() formGroup: FormGroup | undefined;
  @Input() action: string = '';
  @ContentChild(TemplateRef) templateVariable!: TemplateRef<any>;

  constructor(
    public dataService: CRUDService<T>,
    public bsModalRef?: BsModalRef,) {
}
  ngOnInit(): void {
  }

getId(model:any){
    return model.Id;
}

onSubmit(){
    this.Item = Object.assign(this.Item, this.formGroup?.value);
    switch(this.action){
        case "Create": this.onCreate(); break; // create delete update icin Enum yazilabilir.
        case "Update": this.onUpdate(); break;
        case "Delete": this.onDelete(); break;
    }

}

onCreate(){
    this.dataService.create(this.Item ,'Create').subscribe( result => {
       this.checkResult(result);
    });
}

onUpdate(){
    this.dataService.update(this.Item,'Update').subscribe( result => {
       this.checkResult(result);
    },
    error => {
        SwalFirePopUp.swalFireError(error.message);
    });
}

onDelete(){
    this.dataService.delete(this.getId(this.Item),'Delete').subscribe(result => {
        this.checkResult(result);
    },
    error => {
        SwalFirePopUp.swalFireError(this.gRpcExceptionParser(error.error));
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
    this.bsModalRef?.hide();
  }
}
