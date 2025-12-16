using System;

namespace CafeteriaEcommerce.Usuarios
{
    public class Usuario
    {
        // Datos del usuario
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }

        // Datos de domicilio
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CP { get; set; }
        public string Referencias { get; set; }

        public string Rol { get; set; } = "Cliente";

        public Usuario() { }

        public Usuario(string nombre, string username, string password)
        {
            Nombre = nombre;
            Username = username;
            Password = password;
            Rol = "Cliente";
        }

        public Usuario(
            string nombre,
            string username,
            string password,
            string telefono,
            string calle,
            string numero,
            string colonia,
            string ciudad,
            string estado,
            string cp,
            string referencias,
            string rol
            )
        {
            Nombre = nombre;
            Username = username;
            Password = password;
            Telefono = telefono;

            Calle = calle;
            Numero = numero;
            Colonia = colonia;
            Ciudad = ciudad;
            Estado = estado;
            CP = cp;
            Referencias = referencias;
            Rol = "Cliente";
        }
    }
}
