* Creen un nuevo componente, por ejemplo Auth,
que este internamente tenga los componentes Login y Register dentro de una carpeta llamada pages

Ejemplo: Auth/pages/login y auth/pages/register

comando: 
          -ng generate module [url]
          -ng generate component [url]

          -ng g m -routing carpeta/nameroiting --flat
              ng generate module auth/auth-routing --routing --flat

Recuerden tener primero el modulo para que lo importe directamente al modulo mas cercano.

* Agregar rutas para clientes
* Intentar trabajar con templates (ej: el home-page component en productos.)


1° crear el modulo
    ng g m Auth 
    ng g c Auth --flat
2° los componentes del modulo
    ng g c Auth/pages/login 
    ng g c Auth/pages/register
3° el routing
    ng generate module auth/auth-routing --routing --flat
