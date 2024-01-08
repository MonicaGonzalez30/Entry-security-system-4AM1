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
      console.log(this.idMaestro);
      
      this.rService.PostMaestro(this.idMaestro, this.password, this.nombre, this.apPat, this.apMat).subscribe(resultado => {
        if(resultado){
          alert("Registro exitoso.")
        }
        else{
          alert("Error: No pudo realizarse el registro.")
        }
      });
    }
    else if(this.tipoUsuario == 3){
      console.log(this.depto);
      console.log(this.correoA);
      this.rService.PostAdministrativo(this.password, this.nombre, this.apPat, this.apMat, this.depto,this.correoA).subscribe(resultado => {
        if(resultado){
          alert("Registro exitoso.")
        }
        else{
          alert("Error: No pudo realizarse el registro.")
        }
      });
    }
    else if(this.tipoUsuario == 4){
      console.log(this.correoP);
      this.rService.PostPolicia(this.password, this.nombre, this.apPat, this.apMat, this.correoP).subscribe(resultado => {
        if(resultado){
          alert("Registro exitoso.")
        }
        else{
          alert("Error: No pudo realizarse el registro.")
        }
      });
    }
    else if(this.tipoUsuario == 5){
      console.log(this.correoI);
      this.rService.PostIntendencia(this.password, this.nombre, this.apPat, this.apMat, this.correoI).subscribe(resultado => {
        if(resultado){
          alert("Registro exitoso.")
        }
        else{
          alert("Error: No pudo realizarse el registro.")
        }
      });
    }
    else if(this.tipoUsuario == 6){
      console.log(this.correoC);
      this.rService.PostCafeteria(this.password, this.nombre, this.apPat, this.apMat, this.correoC).subscribe(resultado => {
        if(resultado){
          alert("Registro exitoso.")
        }
        else{
          alert("Error: No pudo realizarse el registro.")
        }
      });
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

export interface DTO_Maestro{
  idMaestro:string,
  password:string,
  name:string,
  apePat:string,
  apeMat:string,
  photo:string
}

export interface DTO_Policia {
  idPoli: string,
  password: string,
  name: string,
  apePat: string,
  apeMat: string,
  photo: string,
  correoPoli: string
}


export interface DTO_Intendencia {
  idInten: string,
  password: string,
  name: string,
  apePat: string,
  apeMat: string,
  photo: string,
  correoInten: string
}

export interface DTO_Cafeteria {
  idCafe: string,
  password: string,
  name: string,
  apePat: string,
  apeMat: string,
  photo: string,
  correoCafe: string
}

export interface DTO_Administrativo {
  idAdmin: string,
  password: string,
  name: string,
  apePat: string,
  apeMat: string,
  photo: string,
  departamentoAdmin: string,
  correoAdmin: string
}