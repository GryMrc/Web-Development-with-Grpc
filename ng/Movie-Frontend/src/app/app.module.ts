import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { UserService } from './movie-library/User/service/user.service';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './movie-portal/Home/home/home.component';
import { MovieEditComponent } from './movie-portal/Movie/movie-edit/movie-edit/movie-edit.component';
import { PrivilegeEditComponent } from './movie-portal/User/Privilege/privilege-edit/privilege-edit/privilege-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    MovieEditComponent,
    PrivilegeEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
    
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
