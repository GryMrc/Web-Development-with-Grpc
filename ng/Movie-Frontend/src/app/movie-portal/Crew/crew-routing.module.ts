import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActorListComponent } from './actors/actor-list/actor-list.component';
import { CrewComponent } from './crew.component';
import { DirectorListComponent } from './directors/director-list/director-list.component';

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
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CrewRoutingModule { }
