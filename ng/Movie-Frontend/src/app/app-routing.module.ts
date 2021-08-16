import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './movie-portal/User/Login/login/login.component';





const rootRoutes: Routes = [
    { path: 'OverFrameHome/Dashboard/Index', redirectTo: '/Home/Dashboard/Index', pathMatch: 'full' },
    { path: '', component: LoginComponent },
];

@NgModule({
    imports: [
        RouterModule.forRoot(rootRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
