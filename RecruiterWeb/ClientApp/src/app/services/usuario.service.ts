import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';
import { Usuario } from '../modelos/usuario';
@Injectable
  ({
    providedIn: 'root'
  })

export class UsuarioService
{
  url: string = 'https://localhost:7150/API/usuarios/';
  constructor(private peticion: HttpClient) { }

  dameUsuarios(): Observable<Resultado> {
    return this.peticion.get<Resultado>(this.url);
  }

  agregarUsuario(usuario :Usuario): Observable<Resultado> {
    return this.peticion.post<Resultado>(this.url, usuario);
  }

  //modificarUsuario(usuario: Usuario): Observable<Resultado> {
  //  return this.peticion.put<Resultado>(this.url, usuario);
  //}

}
