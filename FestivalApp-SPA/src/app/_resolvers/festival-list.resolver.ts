import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Festival } from '../_models/festival';
import { FestivalService } from '../_services/festival.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class FestivalListResolver implements Resolve<Festival[]> {
  constructor(
    private festivalService: FestivalService,
    private router: Router
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Festival[]> {
      return this.festivalService.getFestivals()
      .pipe(
        catchError(error => {
            this.router.navigate(['/home']);
            return of(null);
        })
      );
    }
}
