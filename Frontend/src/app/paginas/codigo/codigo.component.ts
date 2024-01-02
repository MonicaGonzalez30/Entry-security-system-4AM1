import { Component } from '@angular/core';
import { HeaderComponent } from '../../comun/header/header.component';
import { FooterComponent } from '../../comun/footer/footer.component';

@Component({
  selector: 'app-codigo',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './codigo.component.html',
  styleUrl: './codigo.component.scss'
})
export class CodigoComponent {

}
