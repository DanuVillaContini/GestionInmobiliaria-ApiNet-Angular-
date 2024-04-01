import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  private http = inject(HttpClient);
  private readonly url = environment.apiUrl;

  constructor() { }

  getProducts():Observable<any> {
    return this.http.get<any>(`${this.url}/Producto`);
    //agregar token cuando agregue lo de auth del back 52:00
  }
}
