import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { UserService } from './movie-library/User/service/user.service';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './movie-portal/Home/home/home.component';
import { MovieEditComponent } from './movie-portal/Movie/movie-edit/movie-edit/movie-edit.component';
import { PrivilegeEditComponent } from './movie-portal/User/Privilege/privilege-edit/privilege-edit/privilege-edit.component';
import { LoadingService } from './movie-library/Loading/loading.service';
import { LoaderInterceptor } from './movie-library/Intercepter/loading-interceptor.service';
import { MyLoaderComponent } from './movie-portal/Loading/my-loader/my-loader.component';
import { PagenotfoundComponent } from './movie-library/PageNotFound/pagenotfound/pagenotfound.component';
import { PrivilegeService } from './movie-library/User/service/privilege.service';
import { MenuComponent } from './movie-portal/Menu/menu/menu.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    MovieEditComponent,
    PrivilegeEditComponent,
    MyLoaderComponent,
    PagenotfoundComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    UserService,
    PrivilegeService,
    LoadingService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
