import { Component, OnInit} from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ListScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/ListScreenBase/list-screen-base/list-screen-base.component';
import { Country } from 'src/app/movie-library/Country/country.model';
import { CountryService } from 'src/app/movie-library/Country/country.service';
import { CountryEditComponent } from '../country-edit/country-edit.component';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent extends ListScreenBaseComponent<Country> implements OnInit {
  constructor(public modalService: BsModalService,
              public countryService: CountryService) 
              {
                super(modalService,countryService)
                this.editScreen = CountryEditComponent;
              }

  ngOnInit(): void {
    if(!this.countryService.dataList.length){
      this.countryService.list();
    }
  }
}
