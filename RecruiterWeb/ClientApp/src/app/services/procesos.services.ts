import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';
@Injectable
  ({
    providedIn: 'root'
  })

export class ProcesosService
{
  url: string = 'https://localhost:7150/API/procesos/';
  constructor(private peticion: HttpClient) { }

  dameProcesos(): Observable<Resultado> {
    return this.peticion.get<Resultado>(this.url);
  }
}
