import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EditScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-edit',
  templateUrl: './privilege-edit.component.html',
  styleUrls: ['./privilege-edit.component.css']
})
export class PrivilegeEditComponent extends EditScreenBaseComponent<Privilege> implements OnInit {


  constructor(
    public privilegeService: PrivilegeService,
    public bsModalRef?: BsModalRef,) {
    super(privilegeService,bsModalRef);
   }

   formGroup = new FormGroup({
     "Id": new FormControl("", Validators.required),
    "Role": new FormControl("", Validators.required),
  });

  ngOnInit(): void {
    
  }

  

 
  
}
