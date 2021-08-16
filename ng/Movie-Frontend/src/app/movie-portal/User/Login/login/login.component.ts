import { Component, Injectable, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

  constructor(private userService:UserService) { }

  form = new FormGroup({
    "UserName": new FormControl("", Validators.required),
    "password": new FormControl("", Validators.required),
  });

  ngOnInit(): void {
    
  }

  onSubmit(){

    this.userService.login(this.user);

  }

}
