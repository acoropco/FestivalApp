import { Component, Input, OnInit } from '@angular/core';
import { Rental } from '../_models/rental';
import { SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-google-maps',
  templateUrl: './google-maps.component.html',
  styleUrls: ['./google-maps.component.css']
})
export class GoogleMapsComponent implements OnInit {
  @Input() rental: Rental;
  address: string;
  link: SafeResourceUrl;

  constructor() {}

  ngOnInit() {
    this.address = this.rental.street + ',' + this.rental.city + ',' + this.rental.county;
    this.link = 'https://maps.google.com/maps?q=' + this.address + '&t=&z=10&ie=UTF8&iwloc=&output=embed';
  }

}
