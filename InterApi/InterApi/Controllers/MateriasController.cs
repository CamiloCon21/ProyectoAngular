using InterApi.Data;
using InterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly InterContext _context;

        public MateriasController(InterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriasModel>>> GetMaterias()
        {
            return await _context.Materias.ToListAsync();
        }

        [HttpGet("matprof/{id}")]
        public async Task<ActionResult<IEnumerable<QMatProf>>> materiasprofesor(int id)
        {
            var query = @"
       select mat.Curso as 'Materia', mat.Creditos, pr.Nombre as 'Profesor', mat.id_materia from materiasprofesor mp 
inner join materias mat on mat.id_materia = mp.id_materia
inner join Profesor pr on pr.id_Profesor = mp.id_Profesor
where mp.id_materia  = @id;
    ";

            var result = await _context.Set<QMatProf>()
                .FromSqlRaw(query, new SqlParameter("@id", id))
                .ToListAsync();

            return Ok(result);
        }
    }
}
