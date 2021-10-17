import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './Authenticate/login/login.component';
import { RegisterComponent } from './Authenticate/register/register.component';
import { MenuComponent } from './menu/menu.component';
import { AppRoutingModule } from '../app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyLoaderComponent } from './Loading/loading.component';



@NgModule({
  declarations: [
      LoginComponent,
      RegisterComponent,
      MenuComponent,
      DashboardComponent,
      MyLoaderComponent
    ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  exports: [
      LoginComponent,
      MyLoaderComponent
  ]
})
export class MovielibModule { }
