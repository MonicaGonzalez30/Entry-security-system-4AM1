import { Component } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { LoginService } from '../servicios/login.service';
import { FormsModule } from '@angular/forms';
import { UsuarioService } from '../servicios/usuario.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  public idUsuario!: string;
  public password!: string;

  constructor(private uService: LoginService, private ruteador: Router, private usuarioService: UsuarioService){ }

  public Iniciar(){
    this.uService.LoginUser(this.idUsuario, this.password).subscribe(resultado => {
      if(resultado){
        this.usuarioService.idUsuario = this.idUsuario; //Guarda el id del usuario
        this.ruteador.navigate(["codigo"]);
      }
      else{
        alert("Identificador de usuario o contraseña incorrectos.")
      }
    });
  }
}
