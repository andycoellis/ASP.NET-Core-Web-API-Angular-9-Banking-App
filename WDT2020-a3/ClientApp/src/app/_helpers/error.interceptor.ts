import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../_services';
import { Router } from '@angular/router';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {

      //Specific errors returned from Http requests can be filtered here

      if (err.status === 401 || err.status === 403) {
        this.authenticationService.logout();
        this.router.navigateByUrl('/401', { replaceUrl: true });

      }

      else if (err.status === 404) {
        this.router.navigateByUrl('/404', { replaceUrl: true });
      }

      //If the error is not stated specifically then a generic error is returned to the user
      else if(err.status !== 400){
        this.router.navigateByUrl('/error', { replaceUrl: true });

      }

      return throwError(err);
    }));
  }
}