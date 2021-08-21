import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './movie-portal/Home/home/home.component';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';





const rootRoutes: Routes = [
    { path: 'OverFrameHome/Dashboard/Index', redirectTo: '/Home/Dashboard/Index', pathMatch: 'full' },
    { path: '', component: HomeComponent },
    { path:'home',component:HomeComponent},
    { path:'login',component:LoginComponent}
];

@NgModule({
    imports: [
        RouterModule.forRoot(rootRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
