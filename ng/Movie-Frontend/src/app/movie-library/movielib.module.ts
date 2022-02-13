import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './Authenticate/login/login.component';
import { RegisterComponent } from './Authenticate/register/register.component';
import { MenuComponent } from './menu/menu.component';
import { AppRoutingModule } from '../app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyLoaderComponent } from './Loading/loading.component';
import { ListScreenBaseComponent } from './Core/ScreenBase/ListScreenBase/list-screen-base/list-screen-base.component';
import { EditScreenBaseComponent } from './Core/ScreenBase/EditScreenBase/edit-screen-base/edit-screen-base.component';



@NgModule({
  declarations: [
      LoginComponent,
      RegisterComponent,
      MenuComponent,
      DashboardComponent,
      MyLoaderComponent,
      ListScreenBaseComponent,
      EditScreenBaseComponent
    ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  exports: [
      LoginComponent,
      MyLoaderComponent,
      ListScreenBaseComponent,
      EditScreenBaseComponent
  ]
})
export class MovielibModule { }
