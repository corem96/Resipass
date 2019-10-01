namespace Resipass.Domain.modelos.Aviso
{
    public class Aviso
    {
        public int Id { get; set; }
        public string Comunicado { get; set; }

        public int UsuarioId { get; set; }
        public Usuario.Usuario Usuario { get; set; }
    }
}