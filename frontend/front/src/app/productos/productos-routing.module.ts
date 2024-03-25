import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalleProductComponent } from './detalle-product/detalle-product.component';

export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path:'detalles',
        component: DetalleProductComponent
      },
      // {
      //   path:'register',
      //   component: RegisterComponent
      // },
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
