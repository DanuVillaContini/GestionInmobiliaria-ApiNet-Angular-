import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrearComponent } from './crear/crear.component';
import { DetallesComponent } from './detalles/detalles.component';


export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path:'detalles',
        component: DetallesComponent
      },
      {
        path:'nuevo',
        component: CrearComponent
      },
      // {
      //   path:'nuevo',
      //   component:
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
export class ReservasRoutingModule { }
