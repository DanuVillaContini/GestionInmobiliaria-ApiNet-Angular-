export interface Producto{
  productoId: number;
  codigo: string;
  barrio: string;
  precio: number | undefined;
  urlImagen: string;
  estado: string;
}
export interface NewProducto{
  codigo: string;
  barrio: string;
  precio: number | undefined;
  urlImagen: string;
}
