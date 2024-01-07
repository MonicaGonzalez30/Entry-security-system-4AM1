import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';
import { VerDatosService } from '../../servicios/ver-datos.service';
import { UsuarioService } from '../../servicios/usuario.service';

@Component({
  selector: 'app-ver-datos',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './ver-datos.component.html',
  styleUrl: './ver-datos.component.scss'
})
export class VerDatosComponent {
  public idUsuario!: string;
  public datos!: DTO_Usuario;

  constructor(private vdService: VerDatosService, private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.idUsuario = this.usuarioService.idUsuario;

    this.vdService.GetDatos(this.idUsuario).subscribe( result => {
      this.datos = result;
    })
  }
}

export interface DTO_Usuario{
  name: string,
  apePat: string,
  apeMat: string,
  photo: string,
  tipoUsuario: string
}