import { Component, OnInit, inject } from '@angular/core';
import { ProductosService } from '../productos.service';
import { Producto } from '../interface/producto.interface';
import { Router } from '@angular/router';


@Component({
  selector: 'app-detalle-product',
  templateUrl: './detalle-product.component.html',
  styleUrl: './detalle-product.component.css'
})
export class DetalleProductComponent implements OnInit{

  constructor(private productService: ProductosService, private router: Router) {}

  title: string = 'PRODUCTOS';
  displayedColumns: string[] = ['codigo', 'barrio', 'precio', 'urlImagen', 'estado', 'acciones'];
  productos: Producto[] = [];

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts()
      .subscribe({
        next: (productos) => {
          this.productos = productos;
          console.log(productos);
        },
        error: err => {
          console.log(err);
        }
      });
  }

  deleteProduct(producto: Producto): void {
    if (confirm(`¿Estás seguro de eliminar el producto ${producto.codigo} - Barrio: ${producto.barrio}?`)) {
      this.productService.deleteProduct(producto.productoId)
        .subscribe({
          next: () => {
            console.log(`Producto ${producto.codigo} eliminado correctamente.`);
            this.getProducts();
          },
          error: err => {
            console.error('Error al eliminar el producto:', err);
          }
        });
    }
  }
}
