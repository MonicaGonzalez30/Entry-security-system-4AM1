import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  public idUsuario: string;

  constructor() {
    this.idUsuario = "";
  }
}