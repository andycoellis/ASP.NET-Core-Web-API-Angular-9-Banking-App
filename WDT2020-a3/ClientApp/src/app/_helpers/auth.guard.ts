import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../_services';

/*
 *  Jason Watmore's Tutorial on angular JWT Athentication
 *  https://jasonwatmore.com/post/2019/06/22/angular-8-jwt-authentication-example-tutorial
 *
 *  This tutorial was heavily used as the backbone to our template for JWT Authentication
 *  and Intercepting Error Behaviour.
 *
 *  It is also noted that our template is constructed of a large mixture of this tutorial
 *  and of the Microsoft Documents too.
 * 
 */

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;
        if (currentUser) {
            // logged in so return true

            return true;
        }

        // not logged in so redirect to login page with the return url

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}