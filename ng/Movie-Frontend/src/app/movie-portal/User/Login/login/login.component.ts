import { Component, Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/movie-library/User/model/user.model';
import { UserService } from 'src/app/movie-library/User/service/user.service';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable()
export class LoginComponent {

  user: User = new User();

  constructor(private userService: UserService,
    private router: Router) {
      localStorage.setItem('isAuthenticate','false');
  }

  form = new FormGroup({
    "UserName": new FormControl("", Validators.required),
    "password": new FormControl("", Validators.required),
  });

  login() {
    this.userService.login(this.user).subscribe(result => {
      if (result.Success) {
        SwalFirePopUp.swalFireSuccess()
        localStorage.setItem('isAuthenticate', 'true');
        this.router.navigate(['']);
      } else {
        SwalFirePopUp.swalFireError(result.Message);
      }
    },
      error => {
        SwalFirePopUp.swalFireError(error);
      });
  }
}
