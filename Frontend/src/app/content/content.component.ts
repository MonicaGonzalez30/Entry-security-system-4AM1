import { Component } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RegistroComponent } from '../registro/registro.component';
import { HeaderComponent } from '../comun/header/header.component';
import { FooterComponent } from '../comun/footer/footer.component';
import { RouterModule } from '@angular/router';
import { CodigoComponent } from '../paginas/codigo/codigo.component';

@Component({
  selector: 'app-content',
  standalone: true,
  imports: [LoginComponent, RegistroComponent, HeaderComponent, FooterComponent, CodigoComponent, RouterModule],
  templateUrl: './content.component.html',
  styleUrl: './content.component.scss'
})
export class ContentComponent {

}
