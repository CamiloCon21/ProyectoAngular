using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterApi.Models
{
    public class EstudianteMaterias
    {
        [Key]  // Define la clave primaria
        public int id_estmat { get; set; }

        [Required]
        [ForeignKey("Materia")]  // Define la llave foránea hacia Materia
        public int id_materia { get; set; }

        [Required]
        [ForeignKey("Estudiante")]  // Define la llave foránea hacia Estudiante
        public int id_estudiante { get; set; }

        // Propiedades de navegación para las relaciones
        public MateriasModel Materia { get; set; }
        public EstudianteModel Estudiante { get; set; }
    }
}
