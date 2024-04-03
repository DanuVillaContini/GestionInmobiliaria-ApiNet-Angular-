import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalleProductComponent } from './detalle-product/detalle-product.component';
import { UpdateProductComponent } from './update-product/update-product.component';
import { CreateProductComponent } from './create-product/create-product.component';

export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path:'detalles',
        component: DetalleProductComponent
      },
      {
        path:'editar/:id',
        component: UpdateProductComponent
      },
      {
        path:'nuevo',
        component: CreateProductComponent
      },
      {
        path: '**',
        redirectTo: 'detalles'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductosRoutingModule { }
