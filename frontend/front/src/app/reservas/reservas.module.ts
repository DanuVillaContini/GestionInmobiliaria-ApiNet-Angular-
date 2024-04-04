import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetallesComponent } from './detalles/detalles.component';
import { CrearComponent } from './crear/crear.component';
import { MaterialModule } from '../shared/material/material.module';
import { ReservasRoutingModule } from './reservas-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { UpdateEstadoComponent } from './update-estado/update-estado.component';



@NgModule({
  declarations: [
    DetallesComponent,
    CrearComponent,
    UpdateEstadoComponent
  ],
  imports: [
    CommonModule,
    ReservasRoutingModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class ReservasModule { }
