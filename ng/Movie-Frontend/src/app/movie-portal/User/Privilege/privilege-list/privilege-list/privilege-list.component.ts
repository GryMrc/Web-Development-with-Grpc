import { Component, Injectable, OnInit } from '@angular/core';
import { ListScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/listScreenBase';
import { Privilege } from 'src/app/movie-library/User/model/privilege.model';
import { PrivilegeService } from 'src/app/movie-library/User/service/privilege.service';

@Component({
  selector: 'app-privilege-list',
  templateUrl: './privilege-list.component.html',
  styleUrls: ['./privilege-list.component.css']
})

@Injectable()
export class PrivilegeListComponent extends ListScreenBase<Privilege>  implements OnInit{
  
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
