import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ListParams } from '../../../ListParams/ListParams';

@Component({
  selector: 'app-list-screen-base',
  templateUrl: './list-screen-base.component.html',
  styleUrls: ['./list-screen-base.component.css']
})
export  class ListScreenBaseComponent implements OnInit{

  @Input() public title: string ='';
  @Input() public pageSize = 10;
  @Input() public pageSizeOptions: number[] = [];
  @Input() public dataList: any[] = []; 
  @Output() pageStateChange: EventEmitter<ListParams> = new EventEmitter();
  currentPage: number = 1;
  constructor() { }
  ngOnInit(){
  }

  pageStateChanged(){
    this.pageStateChange.emit({ pageSize: this.pageSize, page: this.currentPage, pageSizeOptions: this.pageSizeOptions })
  }

}
