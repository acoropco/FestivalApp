import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Rental } from 'src/app/_models/rental';
import sss from '../../../assets/countries.json';

@Component({
  selector: 'app-rental-detailed',
  templateUrl: './rental-detailed.component.html',
  styleUrls: ['./rental-detailed.component.css']
})
export class RentalDetailedComponent implements OnInit {
  rental: Rental;
  country: string;
  jsonDataResult: any;
  @Input() isRentalFormHidden;
  @ViewChild('addRentalForm', {static: true}) editForm: NgForm;

  constructor() {}

  ngOnInit() {
    this.jsonDataResult = JSON.stringify(sss);
    console.log(this.jsonDataResult);
  }

  addRental() {

  }

}
