import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './movie-portal/Home/home/home.component';
import { MovieEditComponent } from './movie-portal/Movie/movie-edit/movie-edit/movie-edit.component';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';
import { PrivilegeEditComponent } from './movie-portal/User/Privilege/privilege-edit/privilege-edit/privilege-edit.component';





const rootRoutes: Routes = [
    { path: 'OverFrameHome/Dashboard/Index', redirectTo: '/Home/Dashboard/Index', pathMatch: 'full' },
    { path: '', component: HomeComponent },
    { path: 'home',component:HomeComponent, children: [
        {path: "movie-edit", component: MovieEditComponent,pathMatch:'full'},
        { path: 'privilege-edit',component:PrivilegeEditComponent}
    ]},
    { path:'login',component:LoginComponent},
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
