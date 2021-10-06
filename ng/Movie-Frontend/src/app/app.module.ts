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
import { PrivilegeListComponent } from './movie-portal/User/Privilege/privilege-list/privilege-list/privilege-list.component';
import { MovieListComponent } from './movie-portal/Movie/movie-list/movie-list/movie-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    PrivilegeEditComponent,
    MyLoaderComponent,
    PagenotfoundComponent,
    MenuComponent,
    PrivilegeListComponent,
    MovieListComponent,
    MovieEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ModalModule,
    NgbModule,
  ],
  providers: [
    UserService,
    PrivilegeService,
    BsModalService,
    LoadingService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
