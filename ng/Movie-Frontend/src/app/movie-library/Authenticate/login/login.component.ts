import { Component, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/movie-library/User/model/user.model';
import { UserService } from 'src/app/movie-library/User/service/user.service';
import { SwalFirePopUp } from 'src/app/movie-library/SwalFire/swalfire.popup';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RegisterComponent } from '../register/register.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable()
export class LoginComponent {

  user: User = new User();
  bsModalRef: BsModalRef | undefined;

  constructor(private userService: UserService,
    private router: Router,
    public modalService: BsModalService) {
      localStorage.setItem('isAuthenticate','false');
  }

  openRegisterModal() {
    this.bsModalRef = this.modalService.show(RegisterComponent);
  }

  login() {
    this.userService.login(this.user).subscribe(result => {
      if (result.Success) {
        SwalFirePopUp.swalFireSuccess("Login")
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
