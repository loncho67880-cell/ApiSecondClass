using Domain.ApiSecond;
using Repository.ApiSecond.EF;
using Repository.ApiSecond.Intefaces;

namespace Repository.ApiSecond.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CarritoDbContext _context;

        public UsuarioRepository(CarritoDbContext context)
        {
            _context = context;
        }

        public bool CreateUser(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();

            return true;
        }

        public Usuario GetUsuario(string user, string password)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == user && u.Password == password);
        }
    }
}
