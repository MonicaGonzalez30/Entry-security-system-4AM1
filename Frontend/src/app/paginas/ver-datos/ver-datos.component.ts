import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';

@Component({
  selector: 'app-ver-datos',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './ver-datos.component.html',
  styleUrl: './ver-datos.component.scss'
})
export class VerDatosComponent {

}
