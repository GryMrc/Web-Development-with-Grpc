import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EditScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';
import { EditScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/editScreenBase';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-edit',
  templateUrl: './privilege-edit.component.html',
  styleUrls: ['./privilege-edit.component.css']
})
export class PrivilegeEditComponent extends EditScreenBase<Privilege> implements OnInit{
  @ViewChild(EditScreenBaseComponent, {static: true}) container!: EditScreenBaseComponent<Privilege>;

  constructor(
    public privilegeService: PrivilegeService) {
    super(privilegeService);
   }
   formGroup = new FormGroup({
     "Id": new FormControl("", Validators.required),
    "Role": new FormControl("", Validators.required),
  });

  ngOnInit(): void {
  }

  

 
  
}
