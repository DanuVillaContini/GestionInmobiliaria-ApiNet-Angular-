import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);
  private readonly url = environment.apiUrl;

  //constructor(private http: HttpClient) { }

  // register():Observable<any>{
  //   return this.http.post<any>('${url}/account')
  // }
}
