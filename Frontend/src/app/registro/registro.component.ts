import { CommonModule, NgComponentOutlet } from '@angular/common';
import { Component} from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [NgComponentOutlet, CommonModule, FormsModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.scss'
})
export class RegistroComponent {
  tipoUsuario: number = 0;
  
  obtenerTipoUsuario() {
    console.log('Tipo de Usuario seleccionado:', this.tipoUsuario);
    // Puedes realizar cualquier lógica adicional con this.tipoUsuario
  }
}