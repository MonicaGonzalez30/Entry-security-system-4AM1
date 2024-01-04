import { Component } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { LoginService } from '../servicios/login.service';
import { FormsModule } from '@angular/forms';

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

  constructor(private uService: LoginService, private ruteador: Router){ }

  public Iniciar(){
    this.uService.LoginUser(this.idUsuario, this.password).subscribe(resultado => {
      //console.log(resultado);
      this.ruteador.navigate(["preguntas"]);
    });
  }
}
