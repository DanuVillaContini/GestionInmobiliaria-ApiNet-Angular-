import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './pages/admin/admin.component';
import { HomeRouitingRoutingModule } from './home-rouiting-routing.module';
import { HomeComponent } from './pages/home/home.component';



@NgModule({
  declarations: [
    AdminComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomeRouitingRoutingModule
  ]
})
export class HomeModule { }
