import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { EditScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';
import { EditScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/editScreenBase';
import { CountryService } from 'src/app/movie-library/Country/country.service';
import { Director } from 'src/app/movie-library/Crew/model/director.model';
import { DirectorService } from 'src/app/movie-library/Crew/service/director.service';

@Component({
  selector: 'app-director-edit',
  templateUrl: './director-edit.component.html',
  styleUrls: ['./director-edit.component.css']
})
export class DirectorEditComponent extends EditScreenBase<Director> implements OnInit {
  @ViewChild(EditScreenBaseComponent, {static: true}) container!: EditScreenBaseComponent<Director>;
  constructor(public dataService: DirectorService,
              public countryService: CountryService) {
    super(dataService);
    
  }
  ngOnInit(): void {
    this.countryService.listAll();
    super.initiate();
  }

  createForm(): void {
    this.container.mainForm = this.container.formBuilder.group({
      Person: new FormGroup({
        Name: new FormControl(),
        Age: new FormControl(),
        Gender: new FormControl(),
        CountryId: new FormControl()
      }),
    });
  }
  
}
