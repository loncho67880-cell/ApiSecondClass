using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuario(string user, string password);
        bool CreateUser(Usuario usuario);
    }
}
