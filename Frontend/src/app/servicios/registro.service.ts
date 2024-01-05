import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  private opcionesHttp  = {
    headers: { 'Content-Type': 'application/json' }
  }

  constructor(private http: HttpClient) { }

  public PostAlumno(boleta:string, password:string, nombre:string, apPat:string, apMat:string, estado:string):Observable<any>{
    var alumnoInfo = {
      boleta:boleta,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:"https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg",
      estado:estado
    };
    return this.http.post("https://localhost:7276/Alumno", JSON.stringify(alumnoInfo), this.opcionesHttp);
  }

  //Agregar aquí los post para los demás usuarios
}
