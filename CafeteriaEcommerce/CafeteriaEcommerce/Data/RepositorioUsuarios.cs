using CafeteriaEcommerce.Usuarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CafeteriaEcommerce.Data
{
    public class RepositorioUsuarios
    {
        private string ruta;

        public RepositorioUsuarios()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string carpeta = Path.Combine(baseDir, "DataBase");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            ruta = Path.Combine(carpeta, "usuarios.json");

            if (!File.Exists(ruta))
                File.WriteAllText(ruta, "[]");
        }

        public List<Usuario> LeerUsuarios()
        {
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Usuario>>(json)
                   ?? new List<Usuario>();
        }

        public void GuardarUsuarios(List<Usuario> usuarios)
        {
            string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }
    }
}
