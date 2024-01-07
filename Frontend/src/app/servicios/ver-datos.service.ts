import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VerDatosService {

  constructor(private http: HttpClient) { }

  public GetDatos(idUsuario: string):Observable<any>{
    return this.http.get(`https://localhost:7276/Usuario/datos/${idUsuario}`);
  }
}