using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionImpresoras.Models
{
    [Table("Color")]
    public class Color
    {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public String Nombre { get; set; }

    }
}
