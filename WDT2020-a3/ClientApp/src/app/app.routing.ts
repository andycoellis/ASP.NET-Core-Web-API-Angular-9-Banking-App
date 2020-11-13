import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './_helpers';
import { LoginComponent } from './components/login';
import { HomeComponent } from './components/home';
import { CustomersComponent, EditCustomerComponent } from './components/customers';
import { AccountsComponent } from './components/accounts';
import { StatementComponent, ChartsComponent } from './components/statement';
import { FetchBillPaysComponent } from './components/billpays';
import { ErrorPageComponent, Error404Component, Error401Component } from './components/errorpage';
import { UserComponent, UserDetailsComponent } from './components/user';


const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'customer/add', component: EditCustomerComponent },
  { path: 'customer/edit/:id', component: EditCustomerComponent },
  { path: 'accounts/:id', component: AccountsComponent },
  { path: 'statement', component: StatementComponent },
  { path: 'statement/:id', component: StatementComponent },
  { path: 'charts', component: ChartsComponent },
  { path: 'charts/:id', component: ChartsComponent },
  { path: 'billpay', component: FetchBillPaysComponent },
  { path: 'users', component: UserComponent },
  { path: 'users/details/:id', component: UserDetailsComponent },
  { path: 'users/lock', component: UserComponent },
  { path: 'billpay/:id', component: FetchBillPaysComponent },
  { path: 'error', component: ErrorPageComponent },
  { path: '401', component: Error401Component },
  { path: '404', component: Error404Component },


  { path: '**', redirectTo: '' }
];

export const AppRoutingModule = RouterModule.forRoot(routes);