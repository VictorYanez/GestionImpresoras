using GestionImpresoras.Models;

namespace GestionImpresoras.DTOs
{
    public class SolicitudShowDTO
    {
        public Solicitud Solicitud { get; set; }
        public bool EnEstadoMaximo { get; set; }
    }
}
