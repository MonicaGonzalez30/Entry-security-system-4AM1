import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-editar-datos',
  standalone: true,
  imports: [HeaderComponent, FooterComponent, CommonModule, FormsModule],
  templateUrl: './editar-datos.component.html',
  styleUrl: './editar-datos.component.scss'
})
export class EditarDatosComponent {
  tipoUsuario: number = 0;
  
  obtenerTipoUsuario() {
    console.log('Tipo de Usuario seleccionado:', this.tipoUsuario);
    // Puedes realizar cualquier lógica adicional con this.tipoUsuario
  }
}
