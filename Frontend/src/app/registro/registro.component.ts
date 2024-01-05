import { CommonModule, NgComponentOutlet } from '@angular/common';
import { Component} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { RegistroService } from '../servicios/registro.service';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [NgComponentOutlet, CommonModule, FormsModule, RouterModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.scss'
})
export class RegistroComponent {
  tipoUsuario: number = 0;
  estadoA: number = 0;
  public tipo!: string;
  public nombre!: string;
  public apPat!: string;
  public apMat!: string;
  public password!: string;
  public boleta!: string;
  public estado: string = "Inscrito";
  public idMaestro!: string;
  public depto!: string;
  public correoA!: string;
  public correoP!: string;
  public correoI!: string;
  public correoC!: string;
  
  obtenerTipoUsuario() {
    if(this.tipoUsuario == 1){
      this.tipo = "Alumno";
    }
    else if(this.tipoUsuario == 2){
      this.tipo = "Maestro";
    }
    else if(this.tipoUsuario == 3){
      this.tipo = "Administrativo";
    }
    else if(this.tipoUsuario == 4){
      this.tipo = "Policia";
    }
    else if(this.tipoUsuario == 5){
      this.tipo = "Intendencia";
    }
    else if(this.tipoUsuario == 6){
      this.tipo = "Cafeteria";
    }
  }

  obtenerEstado() {
    if(this.estadoA == 1){
      this.estado = "Egresado";
    }
  }

  constructor(private rService: RegistroService){ }

  public Registrar(){
    if(this.tipoUsuario == 1){
      this.rService.PostAlumno(this.boleta, this.password, this.nombre, this.apPat, this.apMat, this.estado).subscribe(resultado => {
        if(resultado){
          alert("Registro exitoso.")
        }
        else{
          alert("Error: No pudo realizarse el registro.")
        }
      });
    }
    else if(this.tipoUsuario == 2){
      //console.log(this.idMaestro); Borrar estos comentarios
      
      //Agregar lo mismo que se hizó arriba para el alumno, pero para cada tipo de usuario
    }
    else if(this.tipoUsuario == 3){
      //console.log(this.depto);
      //console.log(this.correoA);
    }
    else if(this.tipoUsuario == 4){
      //console.log(this.correoP);
    }
    else if(this.tipoUsuario == 5){
      //console.log(this.correoI);
    }
    else if(this.tipoUsuario == 6){
      //console.log(this.correoC);
    }
  }
}

export interface DTO_Alumno{
  boleta:string,
  password:string,
  name:string,
  apePat:string,
  apeMat:string,
  photo:string,
  estado:string
}

//Agregar aquí los DTO de los demás usuarios (revisa que lleva cada uno, esta en https://github.com/MonicaGonzalez30/Entry-security-system-4AM1/tree/main/ProyectoBack/Model)