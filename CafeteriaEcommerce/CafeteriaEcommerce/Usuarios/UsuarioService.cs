using CafeteriaEcommerce.Core.Seguridad;
using CafeteriaEcommerce.Core.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeteriaEcommerce.Usuarios
{
    public class UsuarioService
    {
        private readonly string ruta = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "DataBase",
            "usuarios.json"
        );

        private List<Usuario> usuarios;
        private AuthSingleton auth = AuthSingleton.Instancia;

        public UsuarioService()
        {
            CargarUsuarios();
            CrearAdminInicial();
        }

        private void CrearAdminInicial()
        {
            if (!usuarios.Any())
            {
                Usuario admin = new Usuario("Administrador", "admin", "adminpass");
                admin.Rol = "Admin"; // Establecer Rol como Administrador
                usuarios.Add(admin);
                GuardarUsuarios();
                Console.WriteLine("\n[CONFIG] 🛠️  Usuario 'admin' (password: adminpass) creado.");
            }
        }

        private void CargarUsuarios()
        {
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            if (!File.Exists(ruta))
                File.WriteAllText(ruta, "[]");

            string json = File.ReadAllText(ruta);
            // Asegúrate de que los usuarios cargados con un archivo vacío tengan un rol por defecto
            usuarios = JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        // Guarda usuarios en JSON
        private void GuardarUsuarios()
        {
            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }

        public bool Registrar(string nombre, string username, string password)
        {
            if (!CafeteriaEcommerce.Core.Utilidades.Validador.EsTextoValido(nombre) ||
            !CafeteriaEcommerce.Core.Utilidades.Validador.EsTextoValido(username) ||
            !CafeteriaEcommerce.Core.Utilidades.Validador.EsPasswordValido(password))
            {
                return false;
            }


            if (usuarios.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            Usuario nuevo = new Usuario(nombre, username, password);
            // El rol por defecto es "Cliente"
            usuarios.Add(nuevo);
            GuardarUsuarios();
            return true;
        }

        // Login: recibe credenciales y devuelve true si el login fue exitoso
        public bool Login(string username, string password)
        {
            var usuario = usuarios.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);

            if (usuario != null)
            {
                auth.Login(usuario.Username);
                return true;
            }

            return false;
        }
        public void Logout()
        {
            auth.Logout();
        }

        //  Verifica si un usuario es administrador
        public bool EsAdministrador(string username)
        {
            if (string.IsNullOrEmpty(username)) return false;

            var usuario = usuarios.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            return usuario != null && usuario.Rol.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            // devolver una copia para evitar que la lista interna sea modificada directamente
            return usuarios.Select(u => new Usuario(u.Nombre, u.Username, u.Password)).ToList();
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("\n USUARIOS REGISTRADOS:");
            foreach (var u in usuarios)
            {
                Console.WriteLine($"- {u.Username} ({u.Nombre}) [Rol: {u.Rol}]");
            }
        }
    }
}