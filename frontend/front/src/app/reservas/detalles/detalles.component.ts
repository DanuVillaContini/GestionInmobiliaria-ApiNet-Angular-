import { Component, OnInit, inject } from '@angular/core';
import { ReservasService } from '../reservas.service';
import { Router } from '@angular/router';
import { IEstadosReserva, IReporte, IReservas } from '../interface/reserva.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  constructor(
    private reservasService: ReservasService,
    private router: Router,
  ) { }

  displayedColumns: string[] = ['codigo', 'barrio', 'precio', 'urlImagen', 'estado', 'usuario', 'cliente', 'estadoReserva', 'acciones'];
  reservas: IReservas[] = [];
  estadosReserva: IEstadosReserva[] = [];
  estadoSeleccionado: number | null = null;
  reporte: IReporte[] = [];
  totalReservasPorVendedor: any[] = [];
  formSearchReporte!: FormGroup


  ngOnInit(): void {
    this.getReservas();
    this.getEstadosReserva();
    this.getReporte();
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

  checkAprobacionDirecta(reservas: IReservas): void {
    console.log('ReservaId:', reservas.reservaId);
    if (reservas && reservas.reservaId) {
      if (confirm(`¿Quieres hacer una evaluacion automatica para check si la reserva ${reservas.reservaId} posee aprobacion directa?`)) {
        this.reservasService.procesarSolicitudAprobacion(reservas.reservaId)
          .subscribe({
            next: () => {
              alert(`Reserva ${reservas.reservaId} aprobada`);
              this.getReservas();
            },
            error: err => {
              alert('No supero las condiciones necesarias para aprobacion');
              console.error('No supero las condiciones necesarias para aprobacion', err);
            }
          });
      }
    } else {
      alert('Objeto de reserva no válido o reservaId no está definido');
      console.error('Invalid reserva object or reservaId is undefined');
    }
  }

  getReporte(): void {
    this.reservasService.getReporte("TODO")
      .subscribe({
        next: (reporte: IReporte[] | number) => {
          if (typeof reporte === 'number') {
            this.reporte = [{ usuario: "TODO", numeroReservas: reporte }];
          } else {
            this.reporte = reporte;
          }
        },
        error: err => {
          console.log(err);
        }
      });
  }

  getMaxReservas(): number {
    return Math.max(...this.reporte.map(r => r.numeroReservas), 0);
  }
}
