using Domain.ApiSecond;

namespace Bussines.ApiSecond.Interfaces
{
    public interface IUsuarioBussines
    {
        Usuario GetUsuario(string user, string password);

        bool CreateUser(UsuarioDto usuario);
    }
}
