import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EditScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';
import { Country } from 'src/app/movie-library/Country/country.model';
import { CountryService } from 'src/app/movie-library/Country/country.service';

@Component({
  selector: 'app-country-edit',
  templateUrl: './country-edit.component.html',
  styleUrls: ['./country-edit.component.css']
})
export class CountryEditComponent extends EditScreenBaseComponent<Country> implements OnInit {

  constructor(
  public countryService: CountryService,
  public bsModalRef?: BsModalRef) { 
    super(countryService,bsModalRef)
  }
  
  formGroup = new FormGroup({
    "Id": new FormControl("", Validators.required),
   "Name": new FormControl("", Validators.required),
 });
  ngOnInit(): void {
  }

}
