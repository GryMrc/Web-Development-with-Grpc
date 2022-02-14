import { NgModule } from '@angular/core';
import { CrewComponent } from './crew.component';
import { ActorListComponent } from './actors/actor-list/actor-list.component';
import { ActorEditComponent } from './actors/actor-edit/actor-edit.component';
import { RouterModule, Routes } from '@angular/router';
import { DirectorListComponent } from './directors/director-list/director-list.component';
import { DirectorEditComponent } from './directors/director-edit/director-edit.component';
import { MovielibModule } from 'src/app/movie-library/movielib.module';
import { ReactiveFormsModule } from '@angular/forms';
import { DirectorService } from 'src/app/movie-library/Crew/service/director.service';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  {
    path: '',
    // component:CrewComponent,        TO DO:
    // pathMatch:'full',
    children: [
      { path: 'Director', component: DirectorListComponent},
      { path: 'Actor', component: ActorListComponent,pathMatch:'full' }
    ]
  }
];

@NgModule({
  declarations: [
    CrewComponent,
    ActorListComponent,
    ActorEditComponent,
    DirectorListComponent,
    DirectorEditComponent
  ],
  imports: [
    CommonModule, //lazy load modulede *ngIf *ngFor kullanmak icin tekrar olanlari import etmemek icin 
    MovielibModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
  ],
  providers: [
    DirectorService
  ],
  exports:[
    RouterModule,
  ],
})
export class CrewModule { }
