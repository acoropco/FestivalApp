import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../_models/user';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { CustomEncoder } from 'src/app/shared/custom-encoder';
import { ForgotPasswordDto } from 'src/app/_models/forgotPasswordDto';
import { ResetPasswordDto } from 'src/app/_models/resetPasswordDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            localStorage.setItem('user', JSON.stringify(user.user));
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            this.currentUser = user.user;
          }
        })
      );
  }

  register(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  confirmEmail(token: string, email: string) {
    let params = new HttpParams({ encoder: new CustomEncoder() })
    params = params.append('token', token);
    params = params.append('email', email);
    
    return this.http.get(this.baseUrl + 'emailConfirmation', { params: params });
  }

  forgotPassword(body: ForgotPasswordDto) {
    return this.http.post(this.baseUrl + 'forgotPassword', body);
  }

  resetPassword(body: ResetPasswordDto) {
    return this.http.post(this.baseUrl + 'resetPassword', body);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
