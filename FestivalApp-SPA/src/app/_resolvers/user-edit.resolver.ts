import { Injectable } from '@angular/core';
import { FestivalService } from '../_services/festival.service';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AuthService } from '../_services/auth.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UserEditResolver {
  constructor(
    private festivalService: FestivalService,
    private authService: AuthService,
    private router: Router
    ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.festivalService.getUser(this.authService.decodedToken.nameid)
    .pipe(
      catchError(error => {
        this.router.navigate(['/festivals']);
        return of(null);
      })
    );
  }
}
