import { Component, OnInit, inject } from '@angular/core';
import { AuthService } from './auth/auth.service';
import { AuthStatus } from './auth/interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  private authService = inject(AuthService);
  private router = inject(Router);

  isAuthenticated: boolean = false;
  title = 'front';

  ngOnInit(): void {
      console.log('App Component Iniciado');

      this.authService.checkStatus();

      if(this.authService.authStatus() === AuthStatus.authenticated){
        this.isAuthenticated = true;
      }
  }

  logout(){
    this.authService.logout();
    this.router.navigateByUrl('auth/login');
  }
}
