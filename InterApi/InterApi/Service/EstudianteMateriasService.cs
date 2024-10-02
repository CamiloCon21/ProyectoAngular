using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterApi.Data;
using InterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterApi.Services
{
    public class EstudianteMateriasService
    {
        private readonly InterContext _context;

        public EstudianteMateriasService(InterContext context)
        {
            _context = context;
        }

        // Método para obtener las materias seleccionadas por un estudiante
        public async Task<List<EstudianteMaterias>> ObtenerMateriasPorEstudiante(int estudianteId)
        {
            return await _context.EstudianteMaterias
                .Where(em => em.id_estudiante == estudianteId)
                .ToListAsync();
        }

        // Método para agregar una materia a un estudiante
        public async Task<string> AgregarMateria(int estudianteId, int materiaId)
        {
            // Validar que el estudiante no haya alcanzado el límite de 3 materias
            var materiasSeleccionadas = await _context.EstudianteMaterias
                .Where(em => em.id_estudiante == estudianteId)
                .ToListAsync();

            if (materiasSeleccionadas.Count >= 3)
            {
                return "El estudiante ya ha seleccionado el límite de 3 materias.";
            }

            // Validar que el estudiante no tenga materias con el mismo profesor
            var materiaSeleccionada = await _context.MateriasProfesor
                .FirstOrDefaultAsync(m => m.id_materia == materiaId);

            if (materiaSeleccionada == null)
            {
                return "La materia seleccionada no existe.";
            }

            var profesorId = materiaSeleccionada.id_Profesor;

            var tieneMismaMateria = await _context.EstudianteMaterias
                .Where(em => em.id_estudiante == estudianteId)
                .Join(_context.MateriasProfesor, em => em.id_materia, mp => mp.id_materia, (em, mp) => mp)
                .AnyAsync(mp => mp.id_Profesor == profesorId);

            if (tieneMismaMateria)
            {
                return "El estudiante ya tiene una materia con este profesor.";
            }

            // Agregar la nueva materia al estudiante
            var estudianteMateria = new EstudianteMaterias
            {
                id_estudiante = estudianteId,
                id_materia = materiaId
            };

            await _context.EstudianteMaterias.AddAsync(estudianteMateria);
            await _context.SaveChangesAsync();
            return "Materia agregada correctamente.";
        }

        // Método para eliminar una materia de un estudiante
        public async Task<string> EliminarMateria(int estudianteId, int materiaId)
        {
            var estudianteMateria = await _context.EstudianteMaterias
                .FirstOrDefaultAsync(em => em.id_estudiante == estudianteId && em.id_materia == materiaId);

            if (estudianteMateria == null)
            {
                return "La materia no está asociada con el estudiante.";
            }

            _context.EstudianteMaterias.Remove(estudianteMateria);
            await _context.SaveChangesAsync();
            return "Materia eliminada correctamente.";
        }
    }
}
