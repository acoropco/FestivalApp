import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { ActivatedRoute } from '@angular/router';
import { FestivalService } from 'src/app/_services/festival.service';
import { AuthService } from 'src/app/_services/auth.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  user: User;
  bsConfig: Partial<BsDatepickerConfig>;
  // @ViewChild('editForm', {static: true}) editForm: NgForm;
  // @HostListener('window:beforeunload', ['$event'])
  // unloadNotification($event: any) {
  //   if (this.editForm.dirty) {
  //     $event.returnValue = true;
  //   }
  // }

  constructor(
    private route: ActivatedRoute,
    private festivalService: FestivalService,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data.user;
    });

    this.bsConfig = {
      containerClass: 'theme-blue',
      dateInputFormat: 'DD-MMM-YYYY'
    };
  }

  updateUser() {
    this.festivalService.updateUser(this.authService.decodedToken.nameid, this.user)
    .subscribe(next => {
      // this.editForm.reset();
    }, error => {
      console.log(error);
    });
  }

}
