use inter

create table Estudiante (

id_estudiante INT PRIMARY KEY IDENTITY(1,1),
Nombre varchar(100) Not null,
Apellidos varchar(100) Not null,
Identificacion INT

)

create table Profesor (

id_Profesor INT PRIMARY KEY IDENTITY(1,1),
Nombre varchar(100) Not null,
Apellidos varchar(100) Not null,
Identificacion INT

)

Create table materias (

id_materia INT PRIMARY KEY IDENTITY(1,1),
Curso varchar(100),
Creditos int
)

Create table materiasprofesor(

id_matpro int primary key identity (1,1),
id_materia int,
id_Profesor int,
 CONSTRAINT FK_Profesor_curso FOREIGN KEY (id_materia) REFERENCES materias(id_materia),
 CONSTRAINT FK_Profesor_curso2 FOREIGN KEY(id_Profesor) REFERENCES Profesor(id_Profesor )

)

create table EstudianteMaterias(
id_estmat int primary key identity (1,1),
id_materia int,
id_estudiante int,
 CONSTRAINT FK_Estudiante_materia FOREIGN KEY (id_materia) REFERENCES materias(id_materia),
 CONSTRAINT FK_Estudiante_materia2 FOREIGN KEY(id_estudiante) REFERENCES Estudiante(id_estudiante )
)


INSERT INTO Estudiante (Nombre, Apellidos, Identificacion) VALUES ('Juan', 'Pérez', 12345678);
INSERT INTO Estudiante (Nombre, Apellidos, Identificacion) VALUES ('María', 'González', 23456789);
INSERT INTO Estudiante (Nombre, Apellidos, Identificacion) VALUES ('Luis', 'Fernández', 34567890);
INSERT INTO Estudiante (Nombre, Apellidos, Identificacion) VALUES ('Ana', 'Martínez', 45678901);
INSERT INTO Estudiante (Nombre, Apellidos, Identificacion) VALUES ('Carlos', 'Hernández', 56789012);


INSERT INTO Profesor (Nombre, Apellidos, Identificacion) VALUES ('Carlos', 'López', 11111111);
INSERT INTO Profesor (Nombre, Apellidos, Identificacion) VALUES ('Laura', 'Martínez', 22222222);
INSERT INTO Profesor (Nombre, Apellidos, Identificacion) VALUES ('Javier', 'García', 33333333);
INSERT INTO Profesor (Nombre, Apellidos, Identificacion) VALUES ('Ana', 'Pérez', 44444444);
INSERT INTO Profesor (Nombre, Apellidos, Identificacion) VALUES ('Sofía', 'Ramírez', 55555555);

INSERT INTO materias (Curso, Creditos) VALUES ('Matemáticas', 3);
INSERT INTO materias (Curso, Creditos) VALUES ('Física', 3);
INSERT INTO materias (Curso, Creditos) VALUES ('Química', 3);
INSERT INTO materias (Curso, Creditos) VALUES ('Programación', 3);
INSERT INTO materias (Curso, Creditos) VALUES ('Historia', 3);


INSERT INTO materias (Curso, Creditos) VALUES ('Matemáticas', 3);     -- Materia 1
INSERT INTO materias (Curso, Creditos) VALUES ('Física', 3);          -- Materia 2
INSERT INTO materias (Curso, Creditos) VALUES ('Química', 3);        -- Materia 3
INSERT INTO materias (Curso, Creditos) VALUES ('Programación', 3);   -- Materia 4
INSERT INTO materias (Curso, Creditos) VALUES ('Historia', 3);       -- Materia 5
INSERT INTO materias (Curso, Creditos) VALUES ('Biología', 3);       -- Materia 6
INSERT INTO materias (Curso, Creditos) VALUES ('Literatura', 3);     -- Materia 7
INSERT INTO materias (Curso, Creditos) VALUES ('Geografía', 3);      -- Materia 8
INSERT INTO materias (Curso, Creditos) VALUES ('Arte', 3);           -- Materia 9
INSERT INTO materias (Curso, Creditos) VALUES ('Deportes', 3);       -- Materia 10

-- Profesor 1 - Carlos
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (1, 1);  -- Matemáticas
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (2, 1);  -- Física

-- Profesor 2 - Laura
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (3, 2);  -- Química
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (4, 2);  -- Programación

-- Profesor 3 - Javier
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (5, 3);  -- Historia
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (6, 3);  -- Biología

-- Profesor 4 - Ana
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (7, 4);  -- Literatura
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (8, 4);  -- Geografía

-- Profesor 5 - Sofía
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (9, 5);  -- Arte
INSERT INTO materiasprofesor (id_materia, id_Profesor) VALUES (10, 5); -- Deportes

select * from materiasprofesor order by id_Profesor asc

select * from materias

select * from Estudiante

select * from EstudianteMaterias order by id_estudiante asc