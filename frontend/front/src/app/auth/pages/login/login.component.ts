import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {InterfaceLogin} from './Interface/user-login.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  private fb = inject(FormBuilder)
  private router = inject(Router);
  myFormLogin!: FormGroup
  hide: boolean = true;

  ngOnInit(): void {
    this.myFormLogin = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    })
  }

  togglePasswordVisibility(): void {
    this.hide = !this.hide;
  }


  login(){
    console.log(this.myFormLogin.value);

    const newUsuario = this.myFormLogin.value as InterfaceLogin

    // result ok:
    this.router.navigateByUrl('home')
    // this.router.navigate(['detalle', 1])
  }

}
