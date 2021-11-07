import { HttpClient } from '@angular/common/http';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { CRUDLService } from 'src/app/movie-library/CRUDL/crudl.service';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-edit',
  templateUrl: './privilege-edit.component.html',
  styleUrls: ['./privilege-edit.component.css']
})
export class PrivilegeEditComponent extends CRUDLService<Privilege> implements OnInit {


  constructor(private privilegeService:PrivilegeService,
    public bsModalRef: BsModalRef,
    public httpClient: HttpClient,
    public router: Router) {
    super(httpClient,router,bsModalRef);
   }


   formGroup = new FormGroup({
    "Role": new FormControl("", Validators.required),
  });

  ngOnInit(): void {
    
  }

  

 
  
}
