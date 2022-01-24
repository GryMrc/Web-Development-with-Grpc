import { Component, ContentChild, Input, OnChanges, OnInit, SimpleChanges, TemplateRef, Type } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { CRUDService } from '../../../CRUDService/CRUDService';

@Component({
  selector: 'app-list-screen-base',
  templateUrl: './list-screen-base.component.html',
  styleUrls: ['./list-screen-base.component.css']
})
export class ListScreenBaseComponent<T> implements OnInit {

  @Input() public title: string ='';
  @Input() public pageSize = 10;
  public page = 1;
  @ContentChild(TemplateRef) templateVariable!: TemplateRef<any>;
  
  bsModalRef: BsModalRef | undefined;
  protected editScreen:any;
  public pageSizeOptions: number [] = [10, 20, 30];
  public refresh = new Subject();
  constructor(public modalService: BsModalService, public dataService: CRUDService<T>) { }

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

  refreshList(event:any){
    this.dataService.list({'pageSize':this.pageSize, 'page':this.page});
  }
}
