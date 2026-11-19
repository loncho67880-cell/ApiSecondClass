using Microsoft.AspNetCore.Identity;

namespace Common.ApiSecond.Utilidades
{
    public static class Encripcion
    {
        public static string PasswordEncriptado(string password)
        {
            var hasher = new PasswordHasher<string>();
            return hasher.HashPassword(password, "M9fK4mP8xR2vL7nQ3wZ6tY1bH5jC8dG4sA0eM");
        }
    }
}
