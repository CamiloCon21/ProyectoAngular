using System.ComponentModel.DataAnnotations;

namespace InterApi.Models
{
    public class MateriasModel
    {


        [Key]  // Define la clave primaria
        public int id_materia { get; set; }

        [Required]  // Campo obligatorio
        [StringLength(100)]  // Limita la longitud del string a 100 caracteres
        public string Curso { get; set; }

        [Required]
        public int Creditos { get; set; }
    }
}
