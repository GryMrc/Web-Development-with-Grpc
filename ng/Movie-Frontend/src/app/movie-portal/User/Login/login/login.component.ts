import { Component, Injectable, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/movie-library/User/model/user.model';
import { UserService } from 'src/app/movie-library/User/service/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable()
export class LoginComponent implements OnInit {

  user:User = new User();

  constructor(
    private userService:UserService,
    private router:Router) { }

  form = new FormGroup({
    "UserName": new FormControl("", Validators.required),
    "password": new FormControl("", Validators.required),
  });

  ngOnInit(): void {
    
  }

  onSubmit(){
    this.userService.login(this.user).subscribe(result => {
      if(result.success){
        this.swalFireSuccess()
        localStorage.setItem('isAuthenticate','true');
        this.router.navigate(['home']);
      }else{
        this.swalFireError(result.message);
      }
    },
    error => {
      this.swalFireError(error.message);
  });

  }

  swalFireError(message:string){
   const Toast = Swal.mixin({
      position:'center',
      toast: true,
    })
    Toast.fire({
      icon:'error',
      title: 'UnAuthorized Error',
      text:message,
    })
  }

  swalFireSuccess(){
    const Toast = Swal.mixin({
      toast: true,
      position: 'top-end',
      showConfirmButton: false,
      timer: 1500,
    })
    
    Toast.fire({
      icon: 'success',
      title: 'Loged in successfully'
    })
  }

}
