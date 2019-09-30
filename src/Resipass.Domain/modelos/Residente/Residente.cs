namespace Resipass.Domain.modelos.Residente
{
    public class Residente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}