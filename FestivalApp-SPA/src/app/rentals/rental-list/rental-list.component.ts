import { Component, OnInit } from '@angular/core';
import { FestivalService } from 'src/app/_services/festival.service';
import { Rental } from 'src/app/_models/rental';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-rental-list',
  templateUrl: './rental-list.component.html',
  styleUrls: ['./rental-list.component.css']
})
export class RentalListComponent implements OnInit {
  rentals: Rental[];
  currentRental: Rental;

  constructor(
    private festivalService: FestivalService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.festivalService.getRentals()
    .subscribe(data => {
      this.rentals = data;
      this.currentRental = this.rentals[0];
      this.currentRental.isSelected = true;
      this.spinner.hide();
    });
  }

  selectRental(rental: Rental) {
    this.currentRental.isSelected = false;
    this.currentRental = rental;
    this.currentRental.isSelected = true;
  }

}
