import { Component, OnInit } from '@angular/core';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-edit',
  templateUrl: './privilege-edit.component.html',
  styleUrls: ['./privilege-edit.component.css']
})
export class PrivilegeEditComponent implements OnInit {

  privilege : Privilege = new Privilege();

  constructor(private privilegeService:PrivilegeService) { }

  ngOnInit(): void {
  }

  onCreate(){
    this.privilegeService.create(this.privilege).subscribe(result => {
      if(result.Success){
        SwalFirePopUp.swalFireSuccess()
      }else{
        SwalFirePopUp.swalFireError(result.Message);
      }
    },
    error => {
      SwalFirePopUp.swalFireError(error.message);
    });
  }

}
