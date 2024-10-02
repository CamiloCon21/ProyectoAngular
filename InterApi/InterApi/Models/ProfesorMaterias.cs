using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InterApi.Models
{
    public class ProfesorMaterias
    {
        [Key]  // Define la clave primaria
        public int id_matpro { get; set; }

        [Required]
        [ForeignKey("Materia")]  // Define la llave foránea hacia Materia
        public int id_materia { get; set; }

        [Required]
        [ForeignKey("Profesor")]  // Define la llave foránea hacia Estudiante
        public int id_Profesor { get; set; }

        // Propiedades de navegación para las relaciones
        public MateriasModel Materia { get; set; }
        public ProfesorModel Profesor { get; set; }
        }
}
