namespace GestionImpresoras.DTOs
{
    public class EmailData
    {
        public DateTime? FechaSolicitud { get; set; }
        public string Solicitante { get; set; }
        public string Correo { get; set; }
        public string ImpresoraCodigo { get; set; }
        public string ColorNombre { get; set; }
        public string EstadoSolicitudNombre { get; set; }
    }
}
