import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { IDialogContainer } from 'src/app/movie-library/Core/IDialogContainer/IDialogContainer';
import { EditScreenBaseComponent } from 'src/app/movie-library/Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';
import { EditScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/editScreenBase';
import { Director } from 'src/app/movie-library/Crew/model/director.model';

@Component({
  selector: 'app-director-edit',
  templateUrl: './director-edit.component.html',
  styleUrls: ['./director-edit.component.css']
})
export class DirectorEditComponent extends EditScreenBase<Director> implements OnInit {
  @ViewChild(EditScreenBaseComponent, {static: true}) container!: EditScreenBaseComponent<Director>;
  
  ngOnInit(): void {
  }

  createForm(): void {
    this.container.mainForm = this.container.formBuilder.group({
      Id: new FormControl(),
      Name: new FormControl(),
      Age: new FormControl(),
      Gender: new FormControl(),
      Nationality: new FormControl(),
      CountryId: new FormControl()
    });
  }
  
}
