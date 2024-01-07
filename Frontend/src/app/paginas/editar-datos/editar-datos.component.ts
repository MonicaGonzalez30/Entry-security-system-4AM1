import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UsuarioService } from '../../servicios/usuario.service';
import { EditarDatosService } from '../../servicios/editar-datos.service';

@Component({
  selector: 'app-editar-datos',
  standalone: true,
  imports: [HeaderComponent, FooterComponent, CommonModule, FormsModule],
  templateUrl: './editar-datos.component.html',
  styleUrl: './editar-datos.component.scss'
})
export class EditarDatosComponent {
  public tipoUs: string = "";
  public idUsuario!: string;
  public datos!: DTO_UsuarioE;

  tipoUsuario: number = 0;
  estadoA: number = 0;
  public tipo!: string;
  public nombre!: string;
  public apPat!: string;
  public apMat!: string;
  public password!: string;
  public foto!: string;
  public fotoURL: string = "https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg";
  public estado: string = "Inscrito";
  public depto!: string;
  public correoA!: string;
  public correoP!: string;
  public correoI!: string;
  public correoC!: string;

  obtenerEstado() {
    if(this.estadoA == 1){
      this.estado = "Egresado";
    }
  }

  obtenerFoto(){
    console.log(this.foto);
    if(this.foto){
      this.fotoURL = this.foto;
      alert("Su nueva foto de perfil se actualizará una vez que de click en el botón de guardar información.")
    }
    else{
      alert("Favor de ingresar la URL de la nueva foto de perfil.")
    }
  }

  constructor(private edService: EditarDatosService, private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.idUsuario = this.usuarioService.idUsuario;

    this.edService.GetDatos(this.idUsuario).subscribe( result => {
      this.datos = result;
      this.tipoUs = this.datos.tipoUsuario;
      if(this.tipoUs == "Alumno"){
        this.edService.GetDatAlumno(this.idUsuario).subscribe( result => {
          this.datos = result;
          this.nombre = this.datos.name;
          this.apPat = this.datos.apePat;
          this.apMat = this.datos.apeMat;
          this.password = this.datos.password;
        })
      }
      else if(this.tipoUs == "Administrativo"){
        this.edService.GetDatAdmin(this.idUsuario).subscribe( result => {
          this.datos = result;
          this.nombre = this.datos.name;
          this.apPat = this.datos.apePat;
          this.apMat = this.datos.apeMat;
          this.password = this.datos.password;
          this.depto = this.datos.departamentoAdmin;
          this.correoA = this.datos.correoAdmin;
        })
      }
      else if(this.tipoUs == "Maestro"){
        this.edService.GetDatMaestro(this.idUsuario).subscribe( result => {
          this.datos = result;
          this.nombre = this.datos.name;
          this.apPat = this.datos.apePat;
          this.apMat = this.datos.apeMat;
          this.password = this.datos.password;
        })
      }
      else if(this.tipoUs == "Cafeteria"){
        this.edService.GetDatCafe(this.idUsuario).subscribe( result => {
          this.datos = result;
          this.nombre = this.datos.name;
          this.apPat = this.datos.apePat;
          this.apMat = this.datos.apeMat;
          this.password = this.datos.password;
          this.correoC = this.datos.correoCafe;
        })
      }
      else if(this.tipoUs == "Intendencia"){
        this.edService.GetDatInten(this.idUsuario).subscribe( result => {
          this.datos = result;
          this.nombre = this.datos.name;
          this.apPat = this.datos.apePat;
          this.apMat = this.datos.apeMat;
          this.password = this.datos.password;
          this.correoI = this.datos.correoInten;
        })
      }
      else{
        this.edService.GetDatPoli(this.idUsuario).subscribe( result => {
          this.datos = result;
          this.nombre = this.datos.name;
          this.apPat = this.datos.apePat;
          this.apMat = this.datos.apeMat;
          this.password = this.datos.password;
          this.correoP = this.datos.correoPoli;
        })
      }
    })
  }

  public Actualizar(){
    if(this.tipoUs == "Alumno"){
      this.edService.ActualizarAlumno(this.idUsuario, this.password, this.nombre, this.apPat, this.apMat, this.fotoURL, this.estado).subscribe(resultado => {
        if(resultado){
          alert("Datos actualizados con exito. Ve a la sección de ver datos para mostrar los cambios.")
        }
        else{
          alert("Error: No pudieron actualizarse los datos.")
        }
      });
    }
    else if(this.tipoUs == "Maestro"){
      this.edService.ActualizarMaestro(this.idUsuario, this.password, this.nombre, this.apPat, this.apMat, this.fotoURL).subscribe(resultado => {
        if(resultado){
          alert("Datos actualizados con exito. Ve a la sección de ver datos para mostrar los cambios.")
        }
        else{
          alert("Error: No pudieron actualizarse los datos.")
        }
      });
    }
    else if(this.tipoUs == "Administrativo"){
      this.edService.ActualizarAdmin(this.idUsuario, this.password, this.nombre, this.apPat, this.apMat, this.fotoURL, this.depto, this.correoA).subscribe(resultado => {
        if(resultado){
          alert("Datos actualizados con exito. Ve a la sección de ver datos para mostrar los cambios.")
        }
        else{
          alert("Error: No pudieron actualizarse los datos.")
        }
      });
    }
    else if(this.tipoUs == "Policia"){
      this.edService.ActualizarPolicia(this.idUsuario, this.password, this.nombre, this.apPat, this.apMat, this.fotoURL, this.correoP).subscribe(resultado => {
        if(resultado){
          alert("Datos actualizados con exito. Ve a la sección de ver datos para mostrar los cambios.")
        }
        else{
          alert("Error: No pudieron actualizarse los datos.")
        }
      });
    }
    else if(this.tipoUs == "Intendencia"){
      this.edService.ActualizarInten(this.idUsuario, this.password, this.nombre, this.apPat, this.apMat, this.fotoURL, this.correoI).subscribe(resultado => {
        if(resultado){
          alert("Datos actualizados con exito. Ve a la sección de ver datos para mostrar los cambios.")
        }
        else{
          alert("Error: No pudieron actualizarse los datos.")
        }
      });
    }
    else if(this.tipoUs == "Cafeteria"){
      this.edService.ActualizarCafe(this.idUsuario, this.password, this.nombre, this.apPat, this.apMat, this.fotoURL, this.correoC).subscribe(resultado => {
        if(resultado){
          alert("Datos actualizados con exito. Ve a la sección de ver datos para mostrar los cambios.")
        }
        else{
          alert("Error: No pudieron actualizarse los datos.")
        }
      });
    }
  }
}

export interface DTO_UsuarioE{
  tipoUsuario: string,
  password: string,
  name:string,
  apePat:string,
  apeMat:string,
  photo:string,
  departamentoAdmin: string,
  correoAdmin: string,
  correoCafe: string,
  correoInten: string,
  correoPoli: string
}