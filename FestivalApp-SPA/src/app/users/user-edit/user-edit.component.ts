import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { ActivatedRoute } from '@angular/router';
import { FestivalService } from 'src/app/_services/festival.service';
import { AuthService } from 'src/app/_services/auth.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  user: User;
  isUserFormHidden = true;
  isEmailHidden = true;
  isPasswordHidden = true;
  isRentalFormHidden = true;
  bsConfig: Partial<BsDatepickerConfig>;
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private festivalService: FestivalService,
    private authService: AuthService,
    private datePipe: DatePipe,
    private toastrService: ToastrService
  ) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data.user;
      this.user.dateOfBirth = new Date(this.datePipe.transform(this.user.dateOfBirth, 'dd-MMM-yyyy'));
    });

    this.bsConfig = {
      containerClass: 'theme-blue',
      dateInputFormat: 'DD-MMM-YYYY'
    };
  }

  updateUser() {
    this.user.dateOfBirth = new Date(this.datePipe.transform(this.user.dateOfBirth, 'yyyy-MM-dd'));
    this.festivalService.updateUser(this.authService.decodedToken.nameid, this.user)
    .subscribe(next => {
      this.isUserFormHidden = true;
      this.authService.currentUser.firstName = this.user.firstName;
      this.authService.currentUser.lastName = this.user.lastName;
      this.authService.currentUser.dateOfBirth = this.user.dateOfBirth;
      this.toastrService.success('User updated successfully!');
    }, error => {
      this.toastrService.error('Failed to update user!');
    });
  }

  showUserForm() {
    this.isUserFormHidden = !this.isUserFormHidden;
  }

  showEmail() {
    this.isEmailHidden = !this.isEmailHidden;
  }

  showPassword() {
    this.isPasswordHidden = !this.isPasswordHidden;
  }

  showRentalForm() {
    this.isRentalFormHidden = !this.isRentalFormHidden;
  }

}
