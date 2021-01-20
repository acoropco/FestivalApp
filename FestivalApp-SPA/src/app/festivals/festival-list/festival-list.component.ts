import { Component, OnInit } from '@angular/core';
import { Festival } from 'src/app/_models/festival';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { timeout } from 'rxjs/operators';

@Component({
  selector: 'app-festival-list',
  templateUrl: './festival-list.component.html',
  styleUrls: ['./festival-list.component.css']
})
export class FestivalListComponent implements OnInit {
  festivals: Festival[];

  constructor(
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService
    ) { }

  ngOnInit() {
    this.spinner.show();
    this.route.data.subscribe(data => {
      this.festivals  = data.festivals;
      this.spinner.hide();
    });
  }

}
