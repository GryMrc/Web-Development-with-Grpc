import { Component, Injectable, OnInit } from '@angular/core';
import { NGB_DATEPICKER_TIME_ADAPTER_FACTORY } from '@ng-bootstrap/ng-bootstrap/timepicker/ngb-time-adapter';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
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
      this.dataList = result.Data; // listelemede de donus tipi vermek lazim
    },
    error => {
      SwalFirePopUp.swalFireError(error.statusText)
    })
  }

  openModal(action:string,model?:any) {
    let data = {
      currentItem: model ? model : new Privilege(),
      action: action,
      title: action + " Privilege" // nameOf(privilege) kullanimini arastiricam c# taki gibi
    }
    this.bsModalRef = this.modalService.show(PrivilegeEditComponent,{
      initialState:data
    });
  }
}
