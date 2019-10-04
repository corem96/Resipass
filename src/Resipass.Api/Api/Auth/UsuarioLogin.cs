namespace Resipass.Api.Api.Auth
{
    public class UsuarioLogin
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool EsUsuarioAdmin { get; set; }
    }
}