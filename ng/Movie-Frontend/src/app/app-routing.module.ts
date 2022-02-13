import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './movie-library/Authenticate/login/login.component';
import { DashboardComponent } from './movie-library/dashboard/dashboard.component';
import { PagenotfoundComponent } from './movie-library/PageNotFound/pagenotfound/pagenotfound.component';
import { CountryListComponent } from './movie-portal/Country/country-list/country-list.component';
import { MenuComponent } from './movie-portal/Menu/menu.component';
import { MovieListComponent } from './movie-portal/Movie/movie-list/movie-list/movie-list.component';
import { PrivilegeListComponent } from './movie-portal/User/Privilege/privilege-list/privilege-list/privilege-list.component';





const rootRoutes: Routes = [
    { path: '', component: MenuComponent, 
    children: [
        { path: '', component: DashboardComponent },
        { path: 'home', component: DashboardComponent },
        { path: 'movie-list', component: MovieListComponent },
        { path: 'privilege',component: PrivilegeListComponent},
        { path: 'Crew', loadChildren: () => import('./movie-portal/Crew/crew.module').then(m => m.CrewModule) },
        { path: 'country', component: CountryListComponent },
    ] },
    { path: 'login', component: LoginComponent },
];

@NgModule({
    imports: [
        RouterModule.forRoot(rootRoutes),
        RouterModule.forChild(rootRoutes),
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
