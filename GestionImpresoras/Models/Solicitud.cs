using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionImpresoras.Models
{
    [Table("Solicitud")]
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        public int ImpresoraId { get; set; }
        [Display(Name = "Impresora")]
        public virtual Impresora Impresora { get; set; } = null!; //Perdonar el nulo? y Ademas propiedad de navegacion 

        public int ColorId { get; set; }
        public virtual Color Color { get; set; } = null!;

        public int EstadoSolicitudId { get; set; }
        [Display(Name = "EstadoSolicitud")]
        public virtual EstadoSolicitud EstadoSolicitud { get; set; } = null!; //Perdonar el nulo? y Ademas propiedad de navegacion 

        [Required]
        [Display(Name = "Fecha Sol.")]
        [Column(TypeName = "Date")]
        public DateTime? FechaSolicitud { get; set; }  //El signo ? en DateTime expresa que puede almacenar nulo 

        [Display(Name = "Fecha Entr.")]
        [Column(TypeName = "Date")]
        public DateTime? FechaEntrega { get; set; }  //El signo ? en DateTime expresa que puede almacenar nulo 

        [Required]
        [StringLength(200)]
        public string Solicitante { get; set; }


        [ForeignKey("MedioId")]
        public int MedioId { get; set; }
        public virtual Medio Medio { get; set; } = null!; //Perdonar el nulo? y Ademas propiedad de navegacion 

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "No es una dirección de correo válida")]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string UrlImagen { get; set; }
        //public IFormFile Documento { get; set; }

        [StringLength(200)]
        public string Detalle { get; set; }

    }
}
