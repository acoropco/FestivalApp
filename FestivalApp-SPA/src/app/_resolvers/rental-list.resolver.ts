import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { FestivalService } from '../_services/festival.service';
import { Observable, of } from 'rxjs';
import { Rental } from '../_models/rental';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class RentalListResolver {
  constructor(
    private festivalService: FestivalService,
    private router: Router,
    private toastrService: ToastrService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Rental[]> {
    return this.festivalService.getRentals().pipe(
      catchError((error) => {
        this.toastrService.error('Problem retrieving data');
        this.router.navigate(['/home']);
        return of(null);
      })
    );
  }
}
