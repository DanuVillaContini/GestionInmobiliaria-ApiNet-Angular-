export interface IReservas {
  reservaId: number;
  productoId: number;
  producto: {
    productoId: number;
    codigo: string;
    barrio: string;
    precio: number;
    urlImagen: string;
    estado: string;
  };
  usuario: string;
  clienteNombre: string;
  estadoId: number;
  estadoReserva: {
    estadoId: number;
    nombre: string;
  };
}

export interface ICrearReserva{
  productoId: number;
  usuario: string;
  clienteNombre: string;
}

export interface IEstadosReserva{
  estadoId: number;
  nombre: string;
}
