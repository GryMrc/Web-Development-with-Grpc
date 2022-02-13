import { AfterViewInit, Component, Injectable, OnInit, ViewChild } from '@angular/core';
import { ListScreenBase } from 'src/app/movie-library/Core/ScreenBase/Screen/listScreenBase';
import { Director } from 'src/app/movie-library/Crew/model/director.model';
import { DirectorService } from 'src/app/movie-library/Crew/service/director.service';
import { DirectorEditComponent } from '../director-edit/director-edit.component';

@Component({
  selector: 'app-director-list',
  templateUrl: './director-list.component.html',
  styleUrls: ['./director-list.component.css'],
})
export class DirectorListComponent extends ListScreenBase<Director> implements OnInit, AfterViewInit  {
  
  @ViewChild(DirectorEditComponent, {static: true}) editScreen!: DirectorEditComponent;
  
  constructor(public dataService: DirectorService) { 
    super('Director')
  }
  
  ngOnInit(): void {
    super.initiate();
  }

  ngAfterViewInit(): void {
    this.editScreen.mainScreen = this;
  }
  
  refreshList(): void {
  }

  createEmptyModel(): Director {
    return new Director();
  }
}
