import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { authGuard } from './guards/auth-guard';
import { LoanListComponent } from './features/loan/loan-list/loan-list';
import { CreateLoanComponent } from './features/loan/create-loan/create-loan';
export const routes: Routes = [
    {
        path: 'login', component: LoginComponent
    },
    {
        path: 'dashboard', component: DashboardComponent, canActivate: [authGuard]
    },
    {
        path: 'loans', component: LoanListComponent, canActivate: [authGuard]
    },
    {
        path:'create-loan',component: CreateLoanComponent, canActivate:[authGuard]
    },
    {
        path:'',
        redirectTo: 'login',
        pathMatch: 'full'
    }
];

