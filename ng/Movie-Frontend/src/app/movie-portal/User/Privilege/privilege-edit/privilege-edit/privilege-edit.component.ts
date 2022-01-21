import { HttpClient } from '@angular/common/http';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { CRUDDİALOG } from 'src/app/movie-library/CRUDDİALOG/cruddialog';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-edit',
  templateUrl: './privilege-edit.component.html',
  styleUrls: ['./privilege-edit.component.css']
})
export class PrivilegeEditComponent extends CRUDDİALOG<Privilege> implements OnInit {


  constructor( public bsModalRef: BsModalRef,
    public privilegeService: PrivilegeService) {
    super(bsModalRef, privilegeService);
   }
   
   formGroup = new FormGroup({
     "Id": new FormControl("", Validators.required),
    "Role": new FormControl("", Validators.required),
  });

  ngOnInit(): void {
    
  }

  

 
  
}
