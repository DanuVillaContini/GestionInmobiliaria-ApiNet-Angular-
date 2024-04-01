import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../auth.service';

export const redireccionGuard: CanActivateFn = (route, state) => {

  console.log('Redireccion Guard', route);

  const authService = inject(AuthService);
  const router = inject(Router);

  const currentRol = authService.currentUser()?.role;

  if (currentRol === 'COMERCIAL') {
    router.navigateByUrl('/home')
    return true;
  } else if (currentRol === 'ADMIN') {
    router.navigateByUrl('/productos')
    return true;
  } else if (currentRol === 'VENDEDOR') {
    router.navigateByUrl('/home')
    return true;
  }



  router.navigateByUrl('/auth/login');

  return true;
};
