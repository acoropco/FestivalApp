import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Festival } from '../_models/festival';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class FestivalService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getFestivals() {
    return this.http.get<Festival[]>(this.baseUrl + 'festivals');
  }

  getUser(id: number) {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseUrl + 'users/' + id, user);
  }

  likeFestival(festivalId: number, userId: number) {
    return this.http.post(this.baseUrl + 'festivals/' + festivalId + '/like/' + userId, {});
  }
}
