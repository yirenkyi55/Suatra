import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
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
    return this.http.post<UserModel>(`${this.baseUrl}/login`, model, {
      withCredentials: true,
    });
  }

  refreshToken(model: { token: string }): Observable<UserModel> {
    return this.http.post<UserModel>(`${this.baseUrl}/refresh`, model, {
      withCredentials: true,
    });
  }

  getToken(): string | null {
    const token = localStorage.getItem('authState');
    if (token) {
      return JSON.parse(token)?.auth?.currentUser?.accessToken;
    }
    return null;
  }

  logOut(): Observable<boolean> {
    localStorage.removeItem('authState');
    return of(true);
  }
}
