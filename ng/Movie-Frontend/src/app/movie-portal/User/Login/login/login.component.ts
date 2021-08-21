import { Component, Injectable, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/movie-library/User/model/user.model';
import { UserService } from 'src/app/movie-library/User/service/user.service';

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
        localStorage.setItem('isAuthenticate','true');
        this.router.navigate(['']);
      }
    },
    error => {
      console.log(error)
  });

  }

}
