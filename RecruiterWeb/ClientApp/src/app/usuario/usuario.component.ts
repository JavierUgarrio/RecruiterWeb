import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Usuario } from '../modelos/usuario';
import { UsuarioService } from '../services/usuario.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-usuario-component',
  templateUrl: './usuario.component.html'
})

export class UsuarioComponent implements OnInit  {
  
  altaForm!: FormGroup;
  enviado = false;
  constructor( private usuarioService: UsuarioService, private formBuilder: FormBuilder) {
        
  }
  //Coge los datos del formulario
  ngOnInit(): void {
    this.altaForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      pass: ['', Validators.required],
    })
  }
  //Nos devuelve los controles del formulario
  get f(): { [key: string]: AbstractControl } {
    return this.altaForm.controls;
  }


  public Alta() {

    this.enviado = true;
    if (this.altaForm.invalid) {
      console.log("invalido")
      return;
    }
    console.log("valido");
    let usuario: Usuario = {
      nombre: this.altaForm.controls['nombre'].value ,
      apellidos: this.altaForm.controls['apellidos'].value,
      telefono: this.altaForm.controls['telefono'].value,
      email: this.altaForm.controls['email'].value,
      pass: this.altaForm.controls['pass'].value 
    }


    this.usuarioService.agregarUsuario(usuario).subscribe(res => {
      if (res.error != null && res.error != '') {
        console.log(res.error);
      } else {
        console.log("Exito");
      }
    });  

    //modificar usuario
    //this.usuarioService.modificarUsuario(usuario).subscribe(res => {
    //  if (res.error != null && res.error != '') {
    //    console.log(res.error);
    //  } else {
    //    console.log("Exito en la modificacion");
    //  }
    //}); 

  }
}
