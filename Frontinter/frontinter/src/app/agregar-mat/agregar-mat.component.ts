import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EstudianteModel } from '../models/UserModel';
import { userService } from '../services/user.service';
import { MateriaModel } from '../models/MateriasModel';
import { DetalleMateriaModel } from '../models/MateriasProfModel';

@Component({
  selector: 'app-agregar-mat',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './agregar-mat.component.html',
  styleUrls: ['./agregar-mat.component.css']
})
export class AgregarMatComponent implements OnInit {
  usuario: EstudianteModel | null = null;
  materias: MateriaModel[] = [];
  datosTabla: DetalleMateriaModel[] = [];
  mensaje: string | null = null; // Inicializa el mensaje como null
// Variable para almacenar el mensaje

  constructor(private userService: userService) {}

  ngOnInit(): void {
    // Obtener el usuario actual
    this.usuario = this.userService.getUsuario(); 
    if (this.usuario) {
      console.log('Usuario actual:', this.usuario.nombre);

      // Obtener las materias del usuario actual
      this.userService.traermaterias().subscribe(
        (data: any) => {
          this.materias = data as MateriaModel[];
          console.log('Materias:', this.materias);
        },
        (error) => {
          console.error('Error al obtener materias:', error);
        }
      );
    }
  }

  matprof(id: number) {
    this.userService.traermateriasprof(id).subscribe(
      (data: any) => {
        this.datosTabla = data as DetalleMateriaModel[];
        console.log('Datos de la materia seleccionada:', this.datosTabla);
      },
      (error) => {
        console.error('Error al obtener detalles de la materia:', error);
      }
    );
  }

  AgregarMateria(materiaId: number) {
    if (this.usuario) {
        const estudianteId = this.usuario.id_estudiante; // Asegúrate de que esto esté definido

        this.userService.agregarMateria(estudianteId!, materiaId).subscribe(
            (response) => {
                console.log('Respuesta del servidor:', response); // Verifica la respuesta
                alert(response.mensaje); // Asegúrate de acceder a 'mensaje'
            },
            (error) => {
                console.error('Error al agregar materia:', error);
                alert('Error al agregar la materia');
            }
        );
    } else {
        alert('Usuario no definido.');
    }
}

  
  
}
