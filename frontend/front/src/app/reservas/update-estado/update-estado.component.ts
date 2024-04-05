import { Component, OnInit } from '@angular/core';
import { IEstadosReserva } from '../interface/reserva.interface';
import { ReservasService } from '../reservas.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-update-estado',
  templateUrl: './update-estado.component.html',
  styleUrl: './update-estado.component.css'
})
export class UpdateEstadoComponent implements OnInit{

  constructor(private route: ActivatedRoute,
    private reservasService: ReservasService,
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthService,
  ) { }

  reservaForm!: FormGroup;
  estadosReserva: IEstadosReserva[] = [];
  estadoSeleccionado: number | null = null;
  reservaId!: number;
  estadoId!: number;
  estadoActual!: string;

  ngOnInit(): void {
    this.createForm();
    this.getEstadosReserva();
    this.route.params.subscribe(params => {
      this.reservaId = params['reservaId'];
      this.estadoId = params['estadoId'];
      this.getEstadoActual();
    });
  }

  createForm() {
    this.reservaForm = this.fb.group({
      estadoId: ['', Validators.required],
    });
  }
  getEstadoActual(): void {
    this.reservasService.getReserva(this.reservaId)
      .subscribe(reserva => {
        this.estadoActual = reserva.estadoReserva.nombre;
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
    this.reservaForm.patchValue({
      estadoId: estadoId
    });
  }


  cambiarEstadoReserva() {
    if (this.reservaForm.valid) {
      const estadoId = this.reservaForm.get('estadoId')!.value;

      this.reservasService.updateEstadoReserva(this.reservaId, estadoId)
        .subscribe({
          next: () => {
            alert('El cambio de estado se realizó correctamente');
            this.router.navigate(['/reservas/detalles']);
          },
          error: err => {
            console.error(err);
            alert('Hubo un error al actualizar el estado de la reserva');
          }
        });
    }
  }

  cancelarReserva() {
    this.reservasService.updateEstadoReserva(this.reservaId, 3)
      .subscribe({
        next: () => {
          alert('La reserva ha sido cancelada correctamente');
          this.router.navigate(['/reservas/detalles']);
        },
        error: err => {
          console.error(err);
          alert('Hubo un error al cancelar la reserva');
        }
      });
  }


  showIfRol(): boolean {
    const currentUser = this.authService.currentUser();
    if (currentUser) {
      const allowedRoles = ['VENDEDOR'];
      return allowedRoles.includes(currentUser.role);
    }
    return false;
  }

}
