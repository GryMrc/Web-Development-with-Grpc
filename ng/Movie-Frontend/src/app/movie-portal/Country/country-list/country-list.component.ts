import { AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ListScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/listScreenBase';
import { Country } from 'src/app/movie-library/Country/country.model';
import { CountryService } from 'src/app/movie-library/Country/country.service';
import { CountryEditComponent } from '../country-edit/country-edit.component';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent extends ListScreenBase<Country> implements OnInit, AfterViewInit {

  @ViewChild(CountryEditComponent, {static: true}) editScreen!: CountryEditComponent;
  
  constructor(public modalService: BsModalService,
    public dataService: CountryService) 
    {
      super('Country')
    }
    
    ngOnInit(): void {
      super.initiate();
    }
    
    ngAfterViewInit(): void {
      this.editScreen.mainScreen = this;
    }
    refreshList(): void {
      this.dataService.list(this.listParams);
    }

    createEmptyModel(): Country {
      return new Country();
    }
}
