using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionImpresoras.Models
{
    [Table("Medio")]
    public class Medio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Con Respuesta")]
        public bool ConRespuesta { get; set; }   
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}

