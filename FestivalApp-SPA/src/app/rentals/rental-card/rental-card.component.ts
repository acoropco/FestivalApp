import { Component, Input, OnInit } from '@angular/core';
import { Rental } from 'src/app/_models/rental';

@Component({
  selector: 'app-rental-card',
  templateUrl: './rental-card.component.html',
  styleUrls: ['./rental-card.component.css']
})
export class RentalCardComponent implements OnInit {
  @Input() rental: Rental;

  constructor() { }

  ngOnInit() {
  }

}
