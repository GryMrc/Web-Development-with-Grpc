import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EditScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';
import { EditScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/editScreenBase';
import { Country } from 'src/app/movie-library/Country/country.model';
import { CountryService } from 'src/app/movie-library/Country/country.service';

@Component({
  selector: 'app-country-edit',
  templateUrl: './country-edit.component.html',
  styleUrls: ['./country-edit.component.css']
})
export class CountryEditComponent extends EditScreenBase<Country> {
  @ViewChild(EditScreenBaseComponent, {static: true}) container!: EditScreenBaseComponent<Country>;
  constructor(
  public countryService: CountryService) { 
    super(countryService)
  }
  
  formGroup = new FormGroup({
    "Id": new FormControl("", Validators.required),
   "Name": new FormControl("", Validators.required),
 });
}
