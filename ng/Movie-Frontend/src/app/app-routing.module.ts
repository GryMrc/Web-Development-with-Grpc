import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PagenotfoundComponent } from './movie-library/PageNotFound/pagenotfound/pagenotfound.component';
import { HomeComponent } from './movie-portal/Home/home/home.component';
import { MovieEditComponent } from './movie-portal/Movie/movie-edit/movie-edit/movie-edit.component';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';
import { PrivilegeEditComponent } from './movie-portal/User/Privilege/privilege-edit/privilege-edit/privilege-edit.component';





const rootRoutes: Routes = [
    { path: '',   redirectTo: '/home', pathMatch: 'full' },
    { path: '', component: HomeComponent },
    { path: 'home',component:HomeComponent, children: [
        {path: "movie-edit", component: MovieEditComponent}
        
    ]},
    { path: 'privilege-edit',component:PrivilegeEditComponent},
    { path:'login',component:LoginComponent},
    { path:'**',component:PagenotfoundComponent}
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
