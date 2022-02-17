import { Component, ContentChild, Injectable, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { IDialogContainer } from '../../../IDialogContainer/IDialogContainer';

@Component({
  selector: 'app-edit-screen-base',
  templateUrl: './edit-screen-base.component.html',
  styleUrls: ['./edit-screen-base.component.css']
})

@Injectable()
export class EditScreenBaseComponent<T> implements OnInit, IDialogContainer {
  Item: any;
  title!: string;
  action!: string;
  mainForm!: FormGroup;
  bsModalRef!: BsModalRef;

  @ContentChild('form' , {static: false}) form!: NgForm;
  @ViewChild('modal') modal!: TemplateRef<any>;

  constructor(
    public modalService: BsModalService,
    public formBuilder: FormBuilder) {
}

  ngOnInit(): void {
  }

onAction():void{
    Object.assign(this.Item, this.mainForm.value);
    this.form.ngSubmit.emit();
}

show(){
    this.mainForm.patchValue(this.Item);
    this.bsModalRef = this.modalService.show(this.modal);
}

closeModal() {
    this.bsModalRef?.hide();
  }
}
