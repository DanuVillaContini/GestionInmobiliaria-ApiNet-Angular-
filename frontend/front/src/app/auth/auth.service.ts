import { HttpClient } from '@angular/common/http';
import { Injectable, Signal, computed, inject, signal } from '@angular/core';
import { environment } from '../../environment/environment';
import { Observable, map } from 'rxjs';
import { InterfaceUserRegister, InterfaceUserLogin, User, AuthStatus } from './interface/index';
import * as jwt from 'jwt-decode';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);
  private router = inject(Router);
  private readonly url = environment.apiUrl;

  private _authStatus = signal<AuthStatus>(AuthStatus.checking);
  private _currentUser = signal<User | undefined>(undefined);

  public authStatus = computed(() => this._authStatus());
  public currentUser = computed(() => this._currentUser());

  // constructor(private http: HttpClient) { }

  register(newUser: InterfaceUserRegister): Observable<any> {
    return this.http.post<any>(`${this.url}/Account/Register`, newUser)
  }

  login(userLogin: InterfaceUserLogin): Observable<any> {
    return this.http.post<any>(`${this.url}/Account/Login`, userLogin)
      .pipe(
        map(({ accessToken }) => {
          this.setAuthentication(accessToken);
          return accessToken;
        })
      )
  }

  setAuthentication(token: string | null) {
    if (token) {
      localStorage.setItem('accessToken', token);

      const userResponse = jwt.jwtDecode(token) as User;

      console.log('userResponse: ', userResponse);

      this._authStatus.set(AuthStatus.authenticated);

      this._currentUser.set({
        name: userResponse.name,
        role: userResponse.role,
        exp: userResponse.exp,
      });
    }
    console.log('señal computada: ', this.currentUser());
  }

  checkStatus() {
    const token = localStorage.getItem('accessToken');
    console.log('checkStatus', token);

    this.setAuthentication(token);
  }

  logout() {
    localStorage.removeItem('accessToken');
  }

  getToken(): string | null {
    return localStorage.getItem('accessToken');
  }
}
