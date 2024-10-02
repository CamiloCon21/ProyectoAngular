using InterApi.Data;
using InterApi.Models;
using InterApi.Services; // Asegúrate de tener el servicio disponible
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly InterContext _context;
        private readonly EstudianteMateriasService _estudianteMateriasService;

        public EstudianteController(InterContext context, EstudianteMateriasService estudianteMateriasService)
        {
            _context = context;
            _estudianteMateriasService = estudianteMateriasService;
        }

        // GET: /Estudiante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteModel>>> GetEstudiantes()
        {
            return await _context.Estudiante.ToListAsync();
        }

        [HttpGet("Estudiante/{identificacion}")]
        public async Task<ActionResult<IEnumerable<EstudianteModel>>> estudianteid(int identificacion)
        {
            var query = @"
        SELECT *
FROM 
    Estudiante c 
WHERE 
    c.identificacion like {0}
    ";


            var result = await _context.Set<EstudianteModel>()
                .FromSqlRaw(query, identificacion)  // Pasar el parámetro de año
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("EstudianteMat/{id}")]
        public async Task<ActionResult<IEnumerable<QEstudianteMat>>> materiaestudiante(int id)
        {
            var query = @"
        SELECT 
            es.id_estudiante, 
            es.Nombre AS 'Estudiante', 
            mat.Curso, 
            mat.id_materia,
            pr.Nombre AS 'Nombre_Profesor' 
        FROM 
            EstudianteMaterias em
        INNER JOIN 
            materias mat ON mat.id_materia = em.id_materia
        INNER JOIN 
            estudiante es ON es.id_estudiante = em.id_estudiante
        INNER JOIN 
            materiasprofesor mp ON mp.id_materia = em.id_materia
        INNER JOIN 
            Profesor pr ON pr.id_Profesor = mp.id_Profesor
        WHERE 
            em.id_estudiante = @id;
    ";

            var result = await _context.Set<QEstudianteMat>()
                .FromSqlRaw(query, new SqlParameter("@id", id))
                .ToListAsync();

            return Ok(result);
        }




        // GET: /Estudiante/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteModel>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound("Estudiante no encontrado.");
            }

            return estudiante;
        }

        // POST: /Estudiante
        [HttpPost]
        public async Task<ActionResult<EstudianteModel>> CreateEstudiante(EstudianteModel estudiante)
        {
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.id_estudiante }, estudiante);
        }

        // PUT: /Estudiante/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, EstudianteModel estudiante)
        {
            if (id != estudiante.id_estudiante)
            {
                return BadRequest("El ID del estudiante no coincide.");
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Estudiante.Any(e => e.id_estudiante == id))
                {
                    return NotFound("Estudiante no encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: /Estudiante/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound("Estudiante no encontrado.");
            }

            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: /Estudiante/{id}/AgregarMateria
        [HttpPost("{id}/AgregarMateria")]
        public async Task<ActionResult> AgregarMateria(int id, [FromBody] int materiaId)
        {
            var resultado = await _estudianteMateriasService.AgregarMateria(id, materiaId);

            if (resultado == "Materia agregada correctamente.")
            {
                // Envolver el mensaje en un objeto JSON
                return Ok(new { message = resultado });
            }
            else
            {
                // Envolver el mensaje de error en un objeto JSON
                return BadRequest(new { message = resultado });
            }
        }


        // DELETE: /Estudiante/{id}/EliminarMateria/{materiaId}
        [HttpDelete("{id}/EliminarMateria/{materiaId}")]
        public async Task<ActionResult> EliminarMateria(int id, int materiaId)
        {
            var resultado = await _estudianteMateriasService.EliminarMateria(id, materiaId);

            if (resultado == "Materia eliminada correctamente.")
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }
    }
}
