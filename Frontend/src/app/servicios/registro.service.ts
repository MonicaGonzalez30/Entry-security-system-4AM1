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
    return this.http.post("https://localhost:7276/Alumno/datos", JSON.stringify(alumnoInfo), this.opcionesHttp);
  }

  public PostMaestro(idMaestro:string,password:string,name:string,apePat:string,apeMat:string){
    var maestroInfo = {
      idMaestro:idMaestro,
      password:password,
      name:name,
      apePat:apePat,
      apeMat:apeMat,
      photo:"https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg"
    };
    return this.http.post("https://localhost:7276/Maestro/datos", JSON.stringify(maestroInfo), this.opcionesHttp);
  }
  
  public PostPolicia(password: string, name: string, apePat: string, apeMat: string, correoPoli: string){
    var numAleatorio = Math.floor(Math.random() * 10000); //Genera un numero entre 0 y 9999
    const idP = "P202263" + numAleatorio;
    var policiaInfo = {
      idPoli: idP,
      password: password,
      name: name,
      apePat: apePat,
      apeMat: apeMat,
      photo: "https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg",
      correoPoli: correoPoli
    };
    return this.http.post("https://localhost:7276/Policia/datos", JSON.stringify(policiaInfo), this.opcionesHttp);
  }
  
  public PostIntendencia(password: string, name: string, apePat: string, apeMat: string, correoInten: string){
    var numAleatorio = Math.floor(Math.random() * 10000); //Genera un numero entre 0 y 9999
    const idI = "I202263" + numAleatorio;
    var intendenciaInfo = {
      idInten: idI,
      password: password,
      name: name,
      apePat: apePat,
      apeMat: apeMat,
      photo: "https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg",
      correoInten: correoInten
    };
    return this.http.post("https://localhost:7276/Intendencia/datos", JSON.stringify(intendenciaInfo), this.opcionesHttp);
  }
  
  public PostCafeteria(password: string, name: string, apePat: string, apeMat: string, correoCafe: string){
    var numAleatorio = Math.floor(Math.random() * 10000); //Genera un numero entre 0 y 9999
    const idC = "I202263" + numAleatorio;
    var cafeteriaInfo = {
      idCafe: idC,
      password: password,
      name: name,
      apePat: apePat,
      apeMat: apeMat,
      photo: "https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg",
      correoCafe: correoCafe
    };
    return this.http.post("https://localhost:7276/Cafeteria/datos", JSON.stringify(cafeteriaInfo), this.opcionesHttp);
  }
    
  public PostAdministrativo(password: string, name: string, apePat: string, apeMat: string, departamentoAdmin: string, correoAdmin: string){
    var numAleatorio = Math.floor(Math.random() * 10000); //Genera un numero entre 0 y 9999
    const idA = "A202263" + numAleatorio;
    var administrativoInfo = {
      idAdmin:idA,
      password: password,
      name: name,
      apePat: apePat,
      apeMat: apeMat,
      photo: "https://historiadeltiempopresente.com/wp-content/uploads/2021/01/userdefaultimage.jpg",
      departamentoAdmin: departamentoAdmin,
      correoAdmin: correoAdmin
    };
    return this.http.post("https://localhost:7276/Administrativo/datos", JSON.stringify(administrativoInfo), this.opcionesHttp);
  }
}
