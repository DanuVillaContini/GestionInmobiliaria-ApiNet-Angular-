import { Component, OnInit } from '@angular/core';
import { ReservasService } from '../reservas.service';
import { Router } from '@angular/router';
import { IEstadosReserva, IReservas } from '../interface/reserva.interface';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  constructor(private reservasService: ReservasService, private router: Router) { }

  displayedColumns: string[] = ['codigo', 'barrio', 'precio', 'urlImagen', 'estado', 'usuario', 'cliente', 'estadoReserva', 'acciones'];
  reservas: IReservas[] = [];
  estadosReserva: IEstadosReserva[] = [];
  estadoSeleccionado: number | null = null; // Variable para almacenar el estado seleccionado

  ngOnInit(): void {
    this.getReservas();
    this.getEstadosReserva();
  }

  getReservas(): void {
    this.reservasService.getReservas()
      .subscribe({
        next: (reservas) => {
          this.reservas = reservas;
        },
        error: err => {
          console.log(err);
        }
      });
  }

  getEstadosReserva(): void {
    this.reservasService.getEstadosReserva()
      .subscribe({
        next: (estadosReserva: IEstadosReserva[]) => {
          this.estadosReserva = estadosReserva;
        },
        error: err => {
          console.log(err);
        }
      });
  }

  seleccionEstado(estadoId: number): void {
    this.estadoSeleccionado = estadoId;
    this.filtrarPorEstado(estadoId);
  }

  filtrarPorEstado(estadoId: number): void {
    this.reservasService.getReservasPorEstado(estadoId)
      .subscribe(reservas => {
        this.reservas = reservas;
      });
  }

}
