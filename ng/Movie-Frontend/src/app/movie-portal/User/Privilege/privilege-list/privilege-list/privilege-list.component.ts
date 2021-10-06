import { Component, Injectable, OnInit } from '@angular/core';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-list',
  templateUrl: './privilege-list.component.html',
  styleUrls: ['./privilege-list.component.css']
})

@Injectable()
export class PrivilegeListComponent implements OnInit {
  
  dataList: Privilege [] = []; // bu model belirtme kisimlari CRUDL islemleri icin kalitim alinip extend edilmeli

  constructor(public privilegeService: PrivilegeService) { }

  ngOnInit(): void {
    this.privilegeService.list().subscribe(result => {
      this.dataList = result;
    })
  }
}
