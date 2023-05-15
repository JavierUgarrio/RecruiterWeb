import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio-component',
  templateUrl: './inicio.component.html'
})

export class InicioComponent {

  constructor(private router: Router) { }

  public Navegar() {
    this.router.navigate(['/procesos']);
  }
}
