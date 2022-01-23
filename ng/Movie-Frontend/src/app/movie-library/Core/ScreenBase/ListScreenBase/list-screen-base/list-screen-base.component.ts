import { Component, ContentChild, Input, OnChanges, OnInit, SimpleChanges, TemplateRef, Type } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CRUDService } from '../../../CRUDService/CRUDService';

@Component({
  selector: 'app-list-screen-base',
  templateUrl: './list-screen-base.component.html',
  styleUrls: ['./list-screen-base.component.css']
})
export class ListScreenBaseComponent<T> implements OnInit {

  @Input() dataList: any;
  @Input() title: string ='';
  protected editScreen:any;
  protected modelName: string = '';

  @ContentChild(TemplateRef) templateVariable!: TemplateRef<any>;

  bsModalRef: BsModalRef | undefined;
  constructor(public modalService: BsModalService,public dataService: CRUDService<T>) { }

  ngOnInit(): void {
    if(!this.dataService.dataList.length){
      this.dataService.list();
    }
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
