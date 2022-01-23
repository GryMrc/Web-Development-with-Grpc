import { Component, Injectable, OnInit } from '@angular/core';
import { NGB_DATEPICKER_TIME_ADAPTER_FACTORY } from '@ng-bootstrap/ng-bootstrap/timepicker/ngb-time-adapter';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ListScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/ListScreenBase/list-screen-base/list-screen-base.component';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';
import { PrivilegeEditComponent } from '../../privilege-edit/privilege-edit/privilege-edit.component';

@Component({
  selector: 'app-privilege-list',
  templateUrl: './privilege-list.component.html',
  styleUrls: ['./privilege-list.component.css']
})

@Injectable()
export class PrivilegeListComponent extends ListScreenBaseComponent<Privilege>  implements OnInit {
  
  constructor(public dataService: PrivilegeService,
    public modalService: BsModalService) {
      super(modalService,dataService)
      this.editScreen = PrivilegeEditComponent;
     }

  ngOnInit(): void {
    if(!this.dataService.dataList.length){
        this.dataService.list();
    }
  }
}
