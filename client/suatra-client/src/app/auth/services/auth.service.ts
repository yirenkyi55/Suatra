import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  LoginRequestModel,
  RegisterRequestModel,
  UserModel,
} from 'src/app/core/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = `${environment.baseApiUrl}/auth`;

  constructor(private http: HttpClient) {}

  createAccount(model: RegisterRequestModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/account`, model);
  }

  login(model: LoginRequestModel): Observable<UserModel> {
    return this.http.post<UserModel>(`${this.baseUrl}/login`, model);
  }
}
