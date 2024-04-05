import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home/home.component';
import { authGuard } from './auth/guard/auth.guard';
import { redireccionGuard } from './auth/guard/redireccion.guard';
import { isNotAuthenticatedGuard } from './auth/guard/is-not-authenticated.guard';
import { ProductosModule } from './productos/productos.module';

const routes: Routes = [
  {
    path: 'home',
    canActivate: [authGuard],
    data:{roles: ['ADMIN', 'VENDEDOR','COMERCIAL']},
    loadChildren: () => import('./home/home.module')
    .then(m => m.HomeModule)
  },
  {
    path: 'auth',
    canActivate:[isNotAuthenticatedGuard],
    loadChildren: () => import('./auth/auth.module')
    .then(m => m.AuthModule)
  },
  {
    path: 'productos',
    canActivate: [authGuard],
    data:{roles: ['ADMIN', 'VENDEDOR','COMERCIAL']},
    loadChildren: () => import('./productos/productos.module')
    .then(m => m.ProductosModule)
  },
  {
    path: 'reservas',
    canActivate: [authGuard],
    data:{roles: ['ADMIN', 'VENDEDOR','COMERCIAL']},
    loadChildren: () => import('./reservas/reservas.module')
    .then(m => m.ReservasModule)
  },
  {
    path: '',
    canActivate:[redireccionGuard],
    component: ProductosModule,
  },
  {
    path: '**',
    redirectTo: 'auth/login'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
