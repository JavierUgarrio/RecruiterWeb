/*
 *Creamos la interfaz porque es el tipo de objeto que creamos en Angular y lo enviamos a .net
 */

export interface Usuario {
  id?: number;
  nombre: string;
  apellidos: string;
  telefono: number;
  email: string;
  pass: string;

}
