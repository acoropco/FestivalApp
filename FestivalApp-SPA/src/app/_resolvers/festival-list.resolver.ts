import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Festival } from '../_models/festival';
import { FestivalService } from '../_services/festival.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class FestivalListResolver implements Resolve<Festival[]> {
  constructor(
    private festivalService: FestivalService,
    private router: Router,
    private authService: AuthService,
    private toastrService: ToastrService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Festival[]> {
      return this.festivalService.getFestivals(this.authService.decodedToken.nameid)
      .pipe(
        catchError(error => {
          this.toastrService.error('Problem retrieving data');
          this.router.navigate(['/home']);
          return of(null);
        })
      );
    }
}
