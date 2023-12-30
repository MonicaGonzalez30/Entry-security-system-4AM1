import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './comun/header/header.component';
import { FooterComponent } from './comun/footer/footer.component';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent, LoginComponent, RegistroComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Frontend';
}
