import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRouitingRoutingModule } from './home-rouiting-routing.module';
import { HomeComponent } from './home/home.component';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomeRouitingRoutingModule
  ]
})
export class HomeModule { }
