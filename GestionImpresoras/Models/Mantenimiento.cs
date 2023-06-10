using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionImpresoras.Models
{
    [Table("Mantenimiento")]
    public class Mantenimiento
    {
        [Key]
        public int Id { get; set; }

        public int ImpresoraId { get; set; }
        [Display(Name = "Impresora")]
        public virtual Impresora Impresora { get; set; } = null!; //Perdonar el nulo? y Ademas propiedad de navegacion 

        public int EstadoMttoId { get; set; }
        [Display(Name = "Estado Mtto")]
        public virtual EstadoMtto EstadoMtto { get; set; } = null!; //Perdonar el nulo? y Ademas propiedad de navegacion 

        [Display(Name = "Fecha Sol.")]
        [Column(TypeName = "Date")]
        public DateTime? FechaSolicitud { get; set; }  //El signo ? en DateTime expresa que puede almacenar nulo 

        [Display(Name = "Fecha Mtto.")]
        [Column(TypeName = "Date")]
        public DateTime? FechaMantenimiento { get; set; }  //El signo ? en DateTime expresa que puede almacenar nulo 

        [Display(Name = "Es Local")]
        public bool EsLocal { get; set; }

    }
}
