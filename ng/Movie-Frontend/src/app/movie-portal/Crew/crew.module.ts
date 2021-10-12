import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CrewRoutingModule } from './crew-routing.module';
import { CrewComponent } from './crew.component';
import { ActorListComponent } from './actors/actor-list/actor-list.component';
import { ActorEditComponent } from './actors/actor-edit/actor-edit.component';


@NgModule({
  declarations: [
    CrewComponent,
    ActorListComponent,
    ActorEditComponent
  ],
  imports: [
    CommonModule,
    CrewRoutingModule
  ]
})
export class CrewModule { }
