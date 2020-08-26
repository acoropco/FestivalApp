import { Component, OnInit } from '@angular/core';
import { FestivalService } from 'src/app/_services/festival.service';
import { Festival } from 'src/app/_models/festival';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-festival-list',
  templateUrl: './festival-list.component.html',
  styleUrls: ['./festival-list.component.css']
})
export class FestivalListComponent implements OnInit {
  festivals: Festival[];

  constructor(
    private festivalService: FestivalService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.festivals  = data.festivals;
    });
  }

}
