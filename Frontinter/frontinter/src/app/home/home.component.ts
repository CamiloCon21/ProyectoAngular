import { Component, OnInit } from '@angular/core';
import { userService } from '../services/user.service';
import { EstudianteModel } from '../models/UserModel';
import { CommonModule } from '@angular/common'; 
import { Router } from '@angular/router';
import { estudmat } from '../models/QestudianteMatModel';
import { response } from 'express';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  imports: [CommonModule],
  standalone: true
})
export class HomeComponent implements OnInit {
  usuario: EstudianteModel | null = null;
  datosTabla: estudmat[] = [];
  id_materia : any;// Cambia el tipo según tu necesidad

  constructor(private userService: userService,  private router: Router) {}

  ngOnInit(): void {
    this.usuario = this.userService.getUsuario(); // Obtener el usuario actual
    if (this.usuario) {
      console.log('Usuario actual:', this.usuario.nombre);
      
      this.userService.traertabla(this.usuario.id_estudiante!).then((data : estudmat)=> {
        // Comprobar si data es un array
        if (Array.isArray(data)) {
          this.datosTabla = data 
       
          // Asignar los datos obtenidos a la propiedad
          console.log('Datos de la tabla:', this.datosTabla); // Mostrar los datos en consola
        } else {
          console.error('Los datos recibidos no son un array:', data);
        }
      }).catch(error => {
        console.error('Error al traer la tabla:', error); // Manejo de errores
      });
    } else {
      console.log('No hay usuario validado.');
    }
  }


  Agregarmateria(){
    this.router.navigate(['/AgregarMat']); 
  }

 EliminarMateria(id: number){
   
   console.log('este es el id_materia: '+id)

   const idestudiante = this.usuario?.id_estudiante!
   
 

    this.userService.eliminarmateria(idestudiante,id).subscribe(data =>{
      console.log(data)
    })
  }
}
