using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Repository.ApiSecond.Intefaces;
using Common.ApiSecond.Utilidades;

namespace Bussines.ApiSecond.Bussines
{
    public class UsuarioBussines : IUsuarioBussines
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioBussines(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool CreateUser(UsuarioDto usuario)
        {
            return _usuarioRepository.CreateUser(new Usuario()
            {
                Email = usuario.Email,
                Identificacion = usuario.Identificacion,
                Nombre = usuario.Nombre,
                Password = Encripcion.PasswordEncriptado(usuario.Password),
                Idrol = 7 //7 Idrol Cliente
            });
        }

        public Usuario GetUsuario(string user, string password)
        {
            return _usuarioRepository.GetUsuario(user, password);
        }
    }
}
