import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IReservas, ICrearReserva } from './interface/reserva.interface';
import { environment } from '../../environment/environment';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ReservasService {

  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly url = environment.apiUrl + '/Reserva';
  private readonly url2 = environment.apiUrl + '/estadoReserva';

  constructor() { }

  getProducts():Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/Producto`, { headers });
  }

  getEstadosReserva():Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url2}/`, { headers });
  }

  getReservas(): Observable<IReservas[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<IReservas[]>(`${this.url}`, { headers });
  }

  getReserva(reservaId: number): Observable<IReservas> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<IReservas>(`${this.url}/${reservaId}`, { headers });
  }

  getReservasPorEstado(estadoReservaId: number): Observable<IReservas[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<IReservas[]>(`${this.url}/filtroxestado/${estadoReservaId}`, { headers });
  }

  addNewReserva(reserva: ICrearReserva): Observable<void> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.post<void>(`${this.url}`, reserva, { headers });
  }

  updateEstadoReserva(reservaId: number, estadoId: number): Observable<void> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.put<void>(`${this.url}/updateestado/${reservaId}`, { estadoId }, { headers });
  }

  procesarSolicitudAprobacion(reservaId: number): Observable<void> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.post<void>(`${this.url}/Aprobar/${reservaId}`, { headers });
  }

  getReporte(username: string): Observable<any[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });

    let url = `${this.url}/filtroxusername/${username}`;

    if (username.toUpperCase() === 'TODO') {
      url = `${this.url}/filtroxusername/TODO`;
    }

    return this.http.get<any>(url, { headers });
  }


}
