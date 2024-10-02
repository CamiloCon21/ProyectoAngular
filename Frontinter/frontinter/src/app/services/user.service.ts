import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EstudianteModel } from '../models/UserModel'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class userService {
  APIURL = 'https://localhost:7284/Estudiante';
  APIURL2 = 'https://localhost:7284/';
  private usuarioActual: EstudianteModel | null = null; // Almacena el usuario actual

  constructor(private http: HttpClient) {}

  traerUsuario(id: number): Promise<any> {
    return this.http.get(`${this.APIURL}/Estudiante/${id}`).toPromise();
  }

  traertabla(id: number): Promise<any> {
    return this.http.get(`${this.APIURL}/EstudianteMat/${id}`).toPromise();
  }

  
  traermaterias(){
    return this.http.get(`${this.APIURL2}Materias`)
  }

  traermateriasprof(id: number){
    return this.http.get(`${this.APIURL2}Materias/matprof/${id}`)
  }

  agregarMateria(estudianteId: number, materiaId: number): Observable<{mensaje: string}> {
    const url = `https://localhost:7284/Estudiante/${estudianteId}/AgregarMateria`;
    return this.http.post<{mensaje: string}>(url, materiaId); 
  }
  
 eliminarmateria(estudianteId: number, materiaId: number){
   
  const url= `https://localhost:7284/Estudiante/${estudianteId}/EliminarMateria/${materiaId}`

  return this.http.delete(url);
 }

  // Método para guardar el usuario 
  setUsuario(usuario: EstudianteModel) {
    this.usuarioActual = usuario;
  }

  // Método para obtener el usuario 
  getUsuario(): EstudianteModel | null {
    return this.usuarioActual;
  }
}
