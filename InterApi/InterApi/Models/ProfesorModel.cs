using System.ComponentModel.DataAnnotations;

namespace InterApi.Models
{
    public class ProfesorModel
    {

        [Key]  // Define la clave primaria
        public int id_Profesor { get; set; }

        [Required]  // Campo obligatorio
        [StringLength(100)]  // Limita la longitud del string a 100 caracteres
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        public int Identificacion { get; set; }

        /*Define la relación con la tabla Oficina
        [ForeignKey("Oficina")]
        public int IdOficina { get; set; }

        // Propiedad de navegación para la relación con Oficina
        public Oficina Oficina { get; set; }*/
    }
}
