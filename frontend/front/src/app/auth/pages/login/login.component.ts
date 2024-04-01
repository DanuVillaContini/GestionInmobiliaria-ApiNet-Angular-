import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {InterfaceUserLogin} from '../../interface/index';
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  private authService = inject(AuthService);
  private fb = inject(FormBuilder)
  private router = inject(Router);

  myFormLogin!: FormGroup

  hide: boolean = true;
  togglePasswordVisibility(): void {
    this.hide = !this.hide;
  }

  ngOnInit(): void {
    this.myFormLogin = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    })
  }

  login(){
    console.log(this.myFormLogin.value);

    const Usuario = this.myFormLogin.value as InterfaceUserLogin

    this.authService.login(Usuario).subscribe({
      next: res=>{
        console.log('llego por next',res);
        this.router.navigateByUrl('/')
      },
      error:err=>{
        console.log(err);
      }
    })

    // result ok:
    //this.router.navigateByUrl('home')
    // this.router.navigate(['detalle', 1])
  }

}
