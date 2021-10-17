import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DirectorEditComponent } from '../director-edit/director-edit.component';

@Component({
  selector: 'app-director-list',
  templateUrl: './director-list.component.html',
  styleUrls: ['./director-list.component.css']
})
export class DirectorListComponent implements OnInit {
  bsModalRef: BsModalRef | undefined;
  dataList = [];
  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
    
  }

  openModal(editType:string,model?:any) {
    this.bsModalRef = this.modalService.show(DirectorEditComponent);

    let data = {
      Title: editType + ' Movie ',
      Model: model ? model : null,
      prop3: 'This Can be anything'
    }
  }

}
