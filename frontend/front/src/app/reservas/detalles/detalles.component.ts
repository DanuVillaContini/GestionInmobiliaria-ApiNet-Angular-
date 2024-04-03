import { Component, OnInit } from '@angular/core';
import { ReservasService } from '../reservas.service';
import { Router } from '@angular/router';
import { IReservas } from '../interface/reserva.interface';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrl: './detalles.component.css'
})
export class DetallesComponent implements OnInit {

  constructor(private reservasService: ReservasService, private router: Router) { }

  displayedColumns: string[] = ['codigo', 'barrio', 'precio', 'urlImagen', 'estado', 'usuario', 'cliente', 'estadoReserva', 'acciones'];
  reservas: IReservas[] = [];

  ngOnInit(): void {
    this.getReservas();
  }

  getReservas(): void {
    this.reservasService.getReservas()
      .subscribe({
        next: (reservas) => {
          this.reservas = reservas;
          console.log(reservas);
        },
        error: err => {
          console.log(err);
        }
      });
  }
}
