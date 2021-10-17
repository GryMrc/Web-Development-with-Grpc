import { Component, Injectable, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';
import { PrivilegeEditComponent } from '../../privilege-edit/privilege-edit/privilege-edit.component';

@Component({
  selector: 'app-privilege-list',
  templateUrl: './privilege-list.component.html',
  styleUrls: ['./privilege-list.component.css']
})

@Injectable()
export class PrivilegeListComponent implements OnInit {
  
  dataList: Privilege [] = []; // bu model belirtme kisimlari CRUDL islemleri icin kalitim alinip extend edilmeli
  bsModalRef: BsModalRef | undefined;
  constructor(public privilegeService: PrivilegeService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.privilegeService.list().subscribe(result => {
      this.dataList = result;
    })
  }

  openModal(editType:string,model?:any) {
    this.bsModalRef = this.modalService.show(PrivilegeEditComponent);

    let data = {
      Title: editType + ' Movie ',
      Model: model ? model : null,
      prop3: 'This Can be anything'
    }
  }
}
