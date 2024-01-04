import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ContentComponent } from './content/content.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './servicios/login.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ContentComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [LoginService]
})
export class AppComponent {
  title = 'ESS ESCOM';
}
