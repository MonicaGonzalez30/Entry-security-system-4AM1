import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { PreguntasComponent } from './paginas/preguntas/preguntas.component';

export const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'registro', component: RegistroComponent},
    {path: 'preguntas', component: PreguntasComponent},
    {path: '', redirectTo: '/login', pathMatch: 'full'} //Ruta por defecto
];
