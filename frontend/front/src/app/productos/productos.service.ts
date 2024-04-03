import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environment/environment';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly url = environment.apiUrl;

  constructor() { }

  getProducts():Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/Producto`, { headers });
  }
  getProductById(id: number): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/Producto/${id}`, { headers });
  }

  createProduct(product: any): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.post<any>(`${this.url}/Producto`, product, { headers });
  }

  updateProduct(id: number, product: any): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.put<any>(`${this.url}/Producto/${id}`, product, { headers });
  }

  deleteProduct(id: number): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.delete<any>(`${this.url}/Producto/${id}`, { headers });
  }
}
