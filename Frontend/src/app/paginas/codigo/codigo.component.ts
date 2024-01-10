import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';
import { UsuarioService } from '../../servicios/usuario.service';

@Component({
  selector: 'app-codigo',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './codigo.component.html',
  styleUrl: './codigo.component.scss'
})
export class CodigoComponent {
  public idUsuario!: string;
  public qrImagen!: any;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.idUsuario = this.usuarioService.idUsuario;
    this.qrImagen = "https://localhost:7276/QR/datos/"+this.idUsuario;
  }
}