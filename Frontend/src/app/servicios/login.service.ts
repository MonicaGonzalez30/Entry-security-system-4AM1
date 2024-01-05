import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private opcionesHttp  = {
    headers: { 'Content-Type': 'application/json' }
  }

  constructor(private http: HttpClient) { }

  public LoginUser(idUsuario:string, password:string):Observable<any>{
    var loginInfo = {
      idUsuario: idUsuario,
      password: password
    };
    return this.http.post('https://localhost:7276/Login', JSON.stringify(loginInfo), this.opcionesHttp);
  }
}