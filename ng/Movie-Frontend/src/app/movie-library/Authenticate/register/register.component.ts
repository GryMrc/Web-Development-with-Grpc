import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { User } from 'src/app/movie-library/User/model/user.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';
import { UserService } from 'src/app/movie-library/User/service/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  user: User = new User();
  privileges: Privilege[] = [];
  
  constructor(public bsModalRef: BsModalRef,
    public userService: UserService,
    public privilegeService: PrivilegeService,
    public router:Router) { }

    userForm = new FormGroup({
      "UserName": new FormControl("", Validators.required),
      "password": new FormControl("", Validators.required),
      "PrivilegeId": new FormControl("",Validators.required)
    });

  ngOnInit(): void {
   if(!this.privilegeService.dataList.length){
     this.privilegeService.list();
    }
  }

  onSubmit() {
    this.user = Object.assign(this.user, this.userForm.value);
    this.userService.register(this.user).subscribe(result => {
      if (result.Success) {
        SwalFirePopUp.swalFireSuccess("Registered")
        localStorage.setItem('isAuthenticate', 'true');
        this.bsModalRef.hide();
        this.router.navigate(['']);
      } else {
        SwalFirePopUp.swalFireError(result.Message);
      }
    },
      error => {
        SwalFirePopUp.swalFireError(error);
      });
  }

  closeModal(sendData: any) {
    this.bsModalRef.hide();
  }
}
