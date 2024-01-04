namespace ProyectoBack.Model
{
    public class RegistroEntradaSalida
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string idUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Instalacion { get; set; }
    }
}

