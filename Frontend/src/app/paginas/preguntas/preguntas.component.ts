import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';

@Component({
  selector: 'app-preguntas',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './preguntas.component.html',
  styleUrl: './preguntas.component.scss'
})
export class PreguntasComponent {

}
