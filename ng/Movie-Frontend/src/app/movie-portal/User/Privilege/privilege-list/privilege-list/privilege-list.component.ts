import { Component, Injectable, OnInit, ViewChild } from '@angular/core';
import { ListScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/listScreenBase';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';
import { PrivilegeEditComponent } from '../../privilege-edit/privilege-edit/privilege-edit.component';

@Component({
  selector: 'app-privilege-list',
  templateUrl: './privilege-list.component.html',
  styleUrls: ['./privilege-list.component.css']
})

@Injectable()
export class PrivilegeListComponent extends ListScreenBase<Privilege>  implements OnInit{
  
  @ViewChild(PrivilegeEditComponent, {static: true}) container!: PrivilegeEditComponent;
  
  constructor(public dataService: PrivilegeService) {
    super('Privilege');
  }
  
  refreshList(): void {
    this.dataService.list(this.listParams);
  }
  
  ngOnInit(): void {
    super.initiate();
  }

  createEmptyModel(): Privilege {
    return new Privilege();
  }
}
