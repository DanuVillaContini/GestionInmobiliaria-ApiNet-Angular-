import { Component, OnInit } from '@angular/core';
import { ReservasService } from '../reservas.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ICrearReserva, IReservas } from '../interface/reserva.interface';
import { Producto } from '../../productos/interface/producto.interface';
import { ProductosService } from '../../productos/productos.service';

@Component({
  selector: 'app-crear',
  templateUrl: './crear.component.html',
  styleUrls: ['./crear.component.css']
})
export class CrearComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private reservasService: ReservasService,
    private router: Router,
    private productosService: ProductosService
  ) {
    this.reservaForm = this.fb.group({
      productoId: ['', Validators.required],
      usuario: ['', Validators.required],
      clienteNombre: ['', Validators.required]
    });
  }

  productos: Producto[] = [];
  reservaForm!: FormGroup;

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productosService.getProducts()
      .subscribe({
        next: (productos: Producto[]) => {
          this.productos = productos.filter((producto: Producto) => producto.estado === 'DISPONIBLE');
        },
        error: err => {
          console.log(err);
        }
      });
  }

  seleccionarProducto(producto: Producto): void {
    console.log('Producto seleccionado:', producto);
    this.reservaForm.patchValue({
      productoId: producto.productoId
    });
    console.log('Valor de productoId:', this.reservaForm.get('productoId')?.value);
  }


  Create(): void {
    const reserva: ICrearReserva = this.reservaForm.value;

    this.reservasService.addNewReserva(reserva)
      .subscribe({
        next: () => {
          alert("Reserva creada con éxito");
          this.router.navigate(['/reservas/detalles']);
        },
        error: err => {
          console.log(err);
        }
      });
  }
}
