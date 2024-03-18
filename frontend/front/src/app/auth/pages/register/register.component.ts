import { Component, inject } from '@angular/core';
import {InterfaceRegister} from './Interface/user-register.interface';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  private fb = inject(FormBuilder)
  private router = inject(Router);
  myFormRegister!: FormGroup

  ngOnInit(): void {
    this.myFormRegister = this.fb.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, this.emailValidator]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      esVendedor: ['1', [Validators.required]]
    })
  }

  emailValidator(control: AbstractControl): { [key: string]: any } | null {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (control.value && !emailRegex.test(control.value)) {
      return { 'invalidEmail': true };
    }
    return null;
  }
  register(){
    //console.log(this.myFormRegister.value);

    const esVendedor = this.myFormRegister.value.esVendedor === '1' ? true : false;

    const newUsuario: InterfaceRegister = {
      username: this.myFormRegister.value.username,
      email: this.myFormRegister.value.email,
      password: this.myFormRegister.value.password,
      esVendedor: esVendedor
    };

    console.log(newUsuario)
    // Redirect:
    this.router.navigateByUrl('/auth/login')

  }
}
