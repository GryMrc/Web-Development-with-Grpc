import { Component, ContentChild, Input, OnChanges, OnInit, SimpleChanges, TemplateRef, Type } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CRUDService } from '../../../CRUDService/CRUDService';

@Component({
  selector: 'app-list-screen-base',
  templateUrl: './list-screen-base.component.html',
  styleUrls: ['./list-screen-base.component.css']
})
export class ListScreenBaseComponent<T> implements OnInit {

  @Input() public title: string ='';
  @ContentChild(TemplateRef) templateVariable!: TemplateRef<any>;
  
  bsModalRef: BsModalRef | undefined;
  protected editScreen:any;
  constructor(public modalService: BsModalService) { }

  ngOnInit(): void {
  }

  openModal(action:string,model?:any) {
    let data = {
      Item: model ? model : null,
      action: action,
      title: action + ' ' + this.title // nameOf(privilege) kullanimini arastiricam c# taki gibi
    }
    this.bsModalRef = this.modalService.show(this.editScreen,{
      initialState:data
    });
  }
}
