import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReservasService } from '../reservas.service';
import { IEstadosReserva, IReporte, IReservas } from '../interface/reserva.interface';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrl: './reporte.component.css'
})
export class ReporteComponent implements OnInit {

  constructor(
    private reservasService: ReservasService,
    private router: Router,
  ) { }

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


