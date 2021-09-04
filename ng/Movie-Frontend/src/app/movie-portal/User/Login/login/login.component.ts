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
        this.swalFireSuccess('Login Success')
        localStorage.setItem('isAuthenticate','true');
        this.router.navigate(['home']);
      }else{
        this.swalFireError(result.message);
      }
    },
    error => {
      
  });

  }

  swalFireError(message:string){
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: message
    })
  }

  swalFireSuccess(message:string){
    Swal.fire({
      icon: 'success',
      title: 'Success',
      text: message
    })
  }

}
