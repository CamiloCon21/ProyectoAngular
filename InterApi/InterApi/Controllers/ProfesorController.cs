using InterApi.Data;
using InterApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProfesorController : ControllerBase

    {
        private readonly InterContext _context;

        public ProfesorController(InterContext context)
        {
            _context = context;
        }   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorModel>>> GetProfesor()
        {
            return await _context.Profesor.ToListAsync();
        }
    }
}
