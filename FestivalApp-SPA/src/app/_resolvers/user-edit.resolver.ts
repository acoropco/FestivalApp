import { Injectable } from '@angular/core';
import { FestivalService } from '../_services/festival.service';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AuthService } from '../_services/auth.service';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class UserEditResolver {
  constructor(
    private festivalService: FestivalService,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService
    ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.festivalService.getUser(this.authService.decodedToken.nameid)
    .pipe(
      catchError(error => {
        this.toastrService.error('Problem retrieving your data');
        this.router.navigate(['/festivals']);
        return of(null);
      })
    );
  }
}
