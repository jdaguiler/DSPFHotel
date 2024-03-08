using WebHotelGranChaco.Models;

namespace WebHotelGranChaco.Servicio.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string password);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
