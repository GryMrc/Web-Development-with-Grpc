import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PagenotfoundComponent } from './movie-library/PageNotFound/pagenotfound/pagenotfound.component';
import { HomeComponent } from './movie-portal/Home/home/home.component';
import { MenuComponent } from './movie-portal/Menu/menu/menu.component';
import { MovieEditComponent } from './movie-portal/Movie/movie-edit/movie-edit/movie-edit.component';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';
import { PrivilegeEditComponent } from './movie-portal/User/Privilege/privilege-edit/privilege-edit/privilege-edit.component';
import { PrivilegeListComponent } from './movie-portal/User/Privilege/privilege-list/privilege-list/privilege-list.component';





const rootRoutes: Routes = [
    { path: '', component: MenuComponent,children: [
        { path: '', component: HomeComponent },
        { path: 'home', component: HomeComponent },
        { path: 'privilege-list', component: PrivilegeListComponent }
    ] },
    { path: 'login', component: LoginComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(rootRoutes),
        RouterModule.forChild(rootRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
