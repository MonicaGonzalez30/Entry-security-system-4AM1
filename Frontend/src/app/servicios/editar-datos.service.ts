import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EditarDatosService {
  private opcionesHttp  = {
    headers: { 'Content-Type': 'application/json' }
  }

  constructor(private http: HttpClient) { }

  public GetDatos(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Usuario/datos/${idUsuario}`);
  }

  public GetDatAlumno(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Alumno/datos/${idUsuario}`);
  }

  public GetDatAdmin(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Administrativo/datos/${idUsuario}`);
  }

  public GetDatMaestro(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Maestro/datos/${idUsuario}`);
  }

  public GetDatCafe(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Cafeteria/datos/${idUsuario}`);
  }

  public GetDatInten(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Intendencia/datos/${idUsuario}`);
  }

  public GetDatPoli(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Policia/datos/${idUsuario}`);
  }

  public ActualizarAlumno(boleta:string, password:string, nombre:string, apPat:string, apMat:string, foto:string, estado:string):Observable<any>{
    var alumnoInfo = {
      boleta:boleta,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:foto,
      estado:estado
    };
    return this.http.patch("https://localhost:7276/Alumno/datos", JSON.stringify(alumnoInfo), this.opcionesHttp);
  }

  public ActualizarMaestro(idMaestro:string, password:string, nombre:string, apPat:string, apMat:string, foto:string):Observable<any>{
    var maestroInfo = {
      idMaestro:idMaestro,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:foto
    };
    return this.http.patch("https://localhost:7276/Maestro/datos", JSON.stringify(maestroInfo), this.opcionesHttp);
  }

  public ActualizarAdmin(idAdmin:string, password:string, nombre:string, apPat:string, apMat:string, foto:string, depto:string, correo:string):Observable<any>{
    var adminInfo = {
      idAdmin:idAdmin,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:foto,
      departamentoAdmin:depto,
      correoAdmin:correo
    };
    return this.http.patch("https://localhost:7276/Administrativo/datos", JSON.stringify(adminInfo), this.opcionesHttp);
  }

  public ActualizarPolicia(idPoli:string, password:string, nombre:string, apPat:string, apMat:string, foto:string, correo:string):Observable<any>{
    var poliInfo = {
      idPoli:idPoli,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:foto,
      correoPoli:correo
    };
    return this.http.patch("https://localhost:7276/Policia/datos", JSON.stringify(poliInfo), this.opcionesHttp);
  }

  public ActualizarInten(idInten:string, password:string, nombre:string, apPat:string, apMat:string, foto:string, correo:string):Observable<any>{
    var intenInfo = {
      idInten:idInten,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:foto,
      correoInten:correo
    };
    return this.http.patch("https://localhost:7276/Intendencia/datos", JSON.stringify(intenInfo), this.opcionesHttp);
  }

  public ActualizarCafe(idCafe:string, password:string, nombre:string, apPat:string, apMat:string, foto:string, correo:string):Observable<any>{
    var cafeInfo = {
      idCafe:idCafe,
      password:password,
      name:nombre,
      apePat:apPat,
      apeMat:apMat,
      photo:foto,
      correoCafe:correo
    };
    return this.http.patch("https://localhost:7276/Cafeteria/datos", JSON.stringify(cafeInfo), this.opcionesHttp);
  }
}