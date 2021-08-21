import { Component, OnInit } from '@angular/core';
import {Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('isAuthenticate') != null){
      const isAuthenticate = localStorage.getItem("isAuthenticate");
      if(isAuthenticate == 'false'){
        this.router.navigate(['login']);
      }
    }
  }

  onLogOut(){
    localStorage.setItem('isAuthenticate','false');
    this.router.navigate(['login']);
  }
}
