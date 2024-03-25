import { Component, OnInit, inject } from '@angular/core';
import { ProductosService } from '../productos.service';
import { Producto } from '../interface/producto.interface';

@Component({
  selector: 'app-detalle-product',
  templateUrl: './detalle-product.component.html',
  styleUrl: './detalle-product.component.css'
})
export class DetalleProductComponent implements OnInit{

  private productService = inject(ProductosService);

  title: string = 'Producto Detalles';
  displayedColumns: string[] = ['codigo', 'barrio', 'precio', 'urlImagen', 'estado'];
  productos: Producto[] = [];


  ngOnInit(): void {
      this.productService.getProducts()
      .subscribe({
        next:(productos) => {
          this.productos = productos;
          console.log(productos);
          //53:30
        },
        error: err =>{
          console.log(err);
        }
      })
  }

}
