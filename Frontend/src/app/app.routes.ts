import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { PreguntasComponent } from './paginas/preguntas/preguntas.component';
import { CodigoComponent } from './paginas/codigo/codigo.component';
import { VerDatosComponent } from './paginas/ver-datos/ver-datos.component';

export const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'registro', component: RegistroComponent},
    {path: 'preguntas', component: PreguntasComponent},
    {path: 'codigo', component: CodigoComponent},
    {path: 'verDatos', component: VerDatosComponent},
    {path: '', redirectTo: '/login', pathMatch: 'full'} //Ruta por defecto
];
