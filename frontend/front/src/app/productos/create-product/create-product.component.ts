import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductosService } from '../productos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NewProducto } from '../interface/producto.interface';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.css'
})
export class CreateProductComponent {

  productForm!: FormGroup;
  product!: NewProducto;

  constructor(private fb: FormBuilder,
    private productService: ProductosService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
      this.productForm = this.fb.group({
        codigo:['', [Validators.required]],
        barrio:['', [Validators.required]],
        precio:['', [Validators.required]],
        urlImagen:['']
      })
    }

    create(){
      const {
        codigo, barrio, precio, urlImagen
      } = this.productForm.value;

      const newProduct: NewProducto = {
        codigo: codigo,
        barrio:barrio,
        precio:precio,
        urlImagen:urlImagen
      }

      this.productService.createProduct(newProduct)
      .subscribe({
        next: () =>{
          alert("Producto creado con Exito");
          this.router.navigate(['/productos/detalles']);
        },
        error: err =>{
          console.log(err);
        }

      })
    }


}
