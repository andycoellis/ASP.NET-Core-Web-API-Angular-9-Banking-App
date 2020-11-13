import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './components/home';
import { AccountsComponent } from './components/accounts';
import { FetchBillPaysComponent } from './components/billpays';
import { CustomersComponent, EditCustomerComponent } from './components/customers';
import { StatementComponent, ChartsComponent } from './components/statement';
import { ErrorPageComponent, Error401Component, Error404Component } from './components/errorpage';
import { UserComponent, UserDetailsComponent } from './components/user';


@NgModule({

  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],

  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    LoginComponent,
    AccountsComponent,
    FetchBillPaysComponent,
    CustomersComponent,
    EditCustomerComponent,
    AccountsComponent,
    StatementComponent,
    UserComponent,
    UserDetailsComponent,
    ChartsComponent,
    ErrorPageComponent,
    Error401Component,
    Error404Component
  ],
  //Routing is much leaner here as we have wrapped all routing into its own file
  //app.routing.ts --> This allows for easier error handling and wrapping our headers in
  //JWT Tokens

  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
