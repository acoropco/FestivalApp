import { Component, Input, OnInit } from '@angular/core';
import { Rental } from '../_models/rental';

@Component({
  selector: 'app-google-maps',
  templateUrl: './google-maps.component.html',
  styleUrls: ['./google-maps.component.css']
})
export class GoogleMapsComponent implements OnInit {
  @Input() rental: Rental;

  constructor() {}

  ngOnInit() {
  }

}
