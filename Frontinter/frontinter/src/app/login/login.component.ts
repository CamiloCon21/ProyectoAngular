import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { userService } from '../services/user.service';
import { EstudianteModel } from '../models/UserModel';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [ReactiveFormsModule]
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  usuarios: EstudianteModel[] = [];

  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: userService
  ) {
    // Se crea el formulario con los parámetros usuario y contraseña, ambos obligatorios
    this.form = this.formBuilder.group({
      usuario: ['', [Validators.required]],
      contraseña: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    // Implementación del método (si se necesita)
  }

  ingresoUsuario(event: Event) {
    event.preventDefault(); // Evita el envío del formulario
    console.log('Ingreso')
    const usuarioIngresado = this.form.get('usuario')?.value.trim()
    const contraseñaIngresada = this.form.get('contraseña')?.value.trim();
  
    console.log('Usuario ingresado:', usuarioIngresado); // Mostrar el usuario ingresado
    console.log('Contraseña ingresada:', contraseñaIngresada); // Mostrar la contraseña ingresada
  
    this.userService.traerUsuario(contraseñaIngresada)
      .then(data => {
        if (data && data.length > 0) {
          console.log('Usuarios encontrados en la base de datos:', data); // Mostrar los datos recibidos
  
          // Buscar el usuario que coincida
          const usuarioValido = data.find(
            (usuario: EstudianteModel) => usuario.nombre.trim()== usuarioIngresado && usuario.identificacion== contraseñaIngresada
          );
  
          if (usuarioValido) {
            console.log('Usuario validado:', usuarioValido.nombre);
            this.userService.setUsuario(usuarioValido);
            this.router.navigate(['/home']); // Imprimir el nombre del usuario validado
          } else {
            console.log('Usuario no válido');
          }
  
          this.usuarios = data;
        } else {
          console.log('Usuario no encontrado');
        }
      })
      .catch(error => {
        console.error('Error al traer usuarios:', error); // Manejo de errores
      });
  }
  
  
  
}