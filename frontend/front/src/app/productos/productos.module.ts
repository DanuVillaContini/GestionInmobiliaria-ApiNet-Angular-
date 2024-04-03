import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductosRoutingModule } from './productos-routing.module';
import { DetalleProductComponent } from './detalle-product/detalle-product.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/material/material.module';
import { UpdateProductComponent } from './update-product/update-product.component';
import { CreateProductComponent } from './create-product/create-product.component';


@NgModule({
  declarations: [
    DetalleProductComponent,
    UpdateProductComponent,
    CreateProductComponent
  ],
  imports: [
    CommonModule,
    ProductosRoutingModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class ProductosModule { }
