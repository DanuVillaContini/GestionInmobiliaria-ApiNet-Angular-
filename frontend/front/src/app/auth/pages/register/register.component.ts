import { Component, inject } from '@angular/core';
import { InterfaceUserRegister } from '../../interface/index';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})



export class RegisterComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  selectedValue!: string;
  selectedCar!: string;
  roles: string[] = ['ADMIN', 'COMERCIAL', 'VENDEDOR'];

  myFormRegister!: FormGroup
  usuarioCreado!: InterfaceUserRegister;

  hide: boolean = true;
  togglePasswordVisibility(): void {
    this.hide = !this.hide;
  }

  constructor(private fb: FormBuilder) {
    this.myFormRegister = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['', [Validators.required]]
    })
  }

  register() {
    const {username, password, role} = this.myFormRegister.value;

    const newUser: InterfaceUserRegister = {
      username: username,
      password: password,
      role: role,
    }

    this.authService.register(newUser).subscribe({
      next: res =>{
        console.log(res);
      },
      error: err =>{
        console.log(err);
      }

    //       console.log(newUsuario)
    // // Redirect:
    // this.router.navigateByUrl('/auth/login')
    })
  }
}



// export class RegisterComponent {

//   private fb = inject(FormBuilder)
//   private router = inject(Router);
//   myFormRegister!: FormGroup
//   hide: boolean = true;

//   ngOnInit(): void {
//     this.myFormRegister = this.fb.group({
//       username: ['', [Validators.required]],
//       password: ['', [Validators.required, Validators.minLength(6)]],
//       rol: ['', [Validators.required]]
//     })
//   }

//   togglePasswordVisibility(): void {
//     this.hide = !this.hide;
//   }

//   emailValidator(control: AbstractControl): { [key: string]: any } | null {
//     const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
//     if (control.value && !emailRegex.test(control.value)) {
//       return { 'invalidEmail': true };
//     }
//     return null;
//   }
//   register(){
//     //console.log(this.myFormRegister.value);

//     const esVendedor = this.myFormRegister.value.esVendedor === '1' ? true : false;

//     const newUsuario: InterfaceRegister = {
//       username: this.myFormRegister.value.username,
//       password: this.myFormRegister.value.password,
//       rol: this.myFormRegister.value.rol
//     };

//     console.log(newUsuario)
//     // Redirect:
//     this.router.navigateByUrl('/auth/login')

//   }
// }
