import { Component, OnInit } from '@angular/core';
import {Producto} from '../interface/producto.interface'
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductosService } from '../productos.service';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private productService: ProductosService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  productForm!: FormGroup;
  productId!: number;
  product!: Producto;

  ngOnInit(): void {
    this.createForm();
    this.activatedRoute.paramMap
      .subscribe(params => {
        this.productId = parseInt(params.get('id')!);
        this.getProduct();
      });
  }

  getProduct(): void {
    this.productService.getProductById(this.productId)
      .subscribe(
        (product: Producto) => {
          this.product = product;
          this.productForm.patchValue({
            codigo: product.codigo,
            barrio: product.barrio,
            precio: product.precio,
            urlImagen: product.urlImagen,
          });
        },
        error => {
          console.error('Error al cargar los detalles del producto', error);
        }
      );
  }

  createForm() {
    this.productForm = this.fb.group({
      codigo: ['', Validators.required],
      barrio: ['', Validators.required],
      precio: ['', Validators.required],
      urlImagen: ['']
    });
  }

  Update() {
    if (this.productForm.valid) {
      const productData = this.productForm.value;

      this.productService.updateProduct(this.productId, productData)
        .subscribe({
          next: () => {
            alert("Se ha actualizado correctamente");
            this.router.navigate(['/productos/detalles']);
          },
          error: err => {
            console.log(err);
          }
        });
    } else {
    }
  }
}
