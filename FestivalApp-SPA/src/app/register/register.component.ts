import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, EmailValidator } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { CustomValidators } from 'ng2-validation';
import { AuthService } from '../_services/auth.service';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  user: User;
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.bsConfig = {
      containerClass: 'theme-blue',
      dateInputFormat: 'DD-MMM-YYYY'
    };
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      username: ['', [Validators.required, CustomValidators.email]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: [null, Validators.required],
      clientURI: ['http://localhost:4200/emailconfirmation', Validators.required]
      // city: ['', Validators.required],
      // country: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(formGroup: FormGroup) {
    return formGroup.get('password').value === formGroup.get('confirmPassword').value ? null : {mismatch: true};
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user).subscribe(() => {
        this.toastrService.success('Registration successsful!');
        this.cancel();
      }, error => {
        this.toastrService.error('Failed to register!');
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
