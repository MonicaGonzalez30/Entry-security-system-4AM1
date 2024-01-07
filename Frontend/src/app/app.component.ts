import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ContentComponent } from './content/content.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './servicios/login.service';
import { RegistroService } from './servicios/registro.service';
import { UsuarioService } from './servicios/usuario.service';
import { VerDatosService } from './servicios/ver-datos.service';
import { EditarDatosComponent } from './paginas/editar-datos/editar-datos.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ContentComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [LoginService, RegistroService, UsuarioService, VerDatosService, EditarDatosComponent]
})
export class AppComponent {
  title = 'ESS ESCOM';
}
