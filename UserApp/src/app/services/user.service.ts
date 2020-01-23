import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private _httpClient: HttpClient) {
  }

  create(user: User) {
    return this._httpClient.post<User>(`${environment.url}/api/users`, user);
  }

  get(id: number) {
    return this._httpClient.get<User>(`${environment.url}/api/users/${id}`);
  }

  getAll() {
    return this._httpClient.get<User[]>(`${environment.url}/api/users`);
  }

  update(id: number, user: User) {
    console.log(id);
    return this._httpClient.put<User>(`${environment.url}/api/users/${id}`, user);
  }

  delete(id: Number) {
    return this._httpClient.delete<User>(`${environment.url}/api/users/${id}`);
  }
}
