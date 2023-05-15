import { Component, Injectable, OnInit } from '@angular/core';
import { ProcesosService } from '../services/procesos.services';

@Component({
  selector: 'app-procesos-component',
  templateUrl: './procesos.component.html'
})

export class ProcesosComponent implements OnInit {

  public listaProcesos!: any[];
  constructor(private procesosService: ProcesosService){
    
  }

  ngOnInit(): void {
    this.dameProcesos();
  }
  dameProcesos() {
    this.procesosService.dameProcesos().subscribe(res => {
      this.listaProcesos = res.objetoGenerico;
      //console.log(this.listaProcesos);
    });


  }
 
}
