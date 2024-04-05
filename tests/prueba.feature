Feature: Caso de prueba

Background:

* karate.configure('ssl', false)

* def pagina = 'https://localhost:44337'
* def token = 'eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoidGVzdCIsInJvbGUiOiJBRE1JTiIsImV4cCI6MTcxMjg5NDY4N30.ipC0a--wyrrXPt5m6ibt4BGU574WVu8lPCQXX1KftBHaB_Slbkb1tdFV5HyDwXxWWVORwrH6zEohEJxA6LFasw' 
* def idProducto = 11

Scenario: GET Productos

Given url pagina + '/api/Producto'
And header Authorization = 'Bearer ' + token
When method get
Then status 200




Scenario: POST Productos

Given url pagina + '/api/Producto'
* request
"""
{
    "codigo": "PVRT-0012",
    "barrio": "San Martin",
    "precio": 2500300,
    "urlImagen": "no"
}
"""
And header Authorization = 'Bearer ' + token
When method post
Then status 201





Scenario: put Productos

Given url pagina + '/api/Producto/'+idProducto
"""
{
    "codigo": "string",
    "barrio": "string",
    "precio": 0,
    "urlImagen": "string"
}
"""
And header Authorization = 'Bearer ' + token
When method put
Then status 200




Scenario: delete Productos

Given url pagina + '/api/Producto/'+idProducto
And header Authorization = 'Bearer ' + token
When method delete
Then status 204