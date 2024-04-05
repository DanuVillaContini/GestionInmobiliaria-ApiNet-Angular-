import { Component, OnInit, inject } from '@angular/core';
import { ReservasService } from '../reservas.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IEstadosReserva, IReservas } from '../interface/reserva.interface';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {
  constructor(
    private reservasService: ReservasService,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  displayedColumns: string[] = ['codigo', 'barrio', 'precio', 'urlImagen', 'estado', 'usuario', 'cliente', 'estadoReserva', 'acciones'];
  reservas: IReservas[] = [];
  estadosReserva: IEstadosReserva[] = [];

  estadoSeleccionado: number | null = null;


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

  cancelarReserva(element: IReservas): void {
    if (element.estadoReserva.nombre === 'INGRESADA') {
      this.router.navigate(['/reservas/updateestado', element]);
    } else {
      alert('Acción no permitida, debe ser una reserva ingresada');
    }
  }

  showIfRol(): boolean {
    const currentUser = this.authService.currentUser();
    if (currentUser) {
      const allowedRoles = ['ADMIN', 'VENDEDOR'];
      return allowedRoles.includes(currentUser.role);
    }
    return false;
  }
  showIfRol2(): boolean {
    const currentUser = this.authService.currentUser();
    if (currentUser) {
      const allowedRoles = ['ADMIN', 'COMERCIAL'];
      return allowedRoles.includes(currentUser.role);
    }
    return false;
  }
}
