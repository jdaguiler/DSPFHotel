using Microsoft.EntityFrameworkCore;
using WebHotelGranChaco.Data;
using WebHotelGranChaco.Models;
using WebHotelGranChaco.Servicio.Contrato;

namespace WebHotelGranChaco.Servicio.Implementacion
{
    public class UsuarioService: IUsuarioService
    {
        private readonly WebDbContext _dbContext;
        public UsuarioService(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string password)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.CorreoElectronico == correo && u.Password == password)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
