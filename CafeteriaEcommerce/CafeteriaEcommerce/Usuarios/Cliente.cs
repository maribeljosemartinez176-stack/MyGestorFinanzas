using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Usuarios
{
    public class Cliente : Usuario
    {
        // Constructor vacío necesario para evitar errores al instanciar
        public Cliente() : base()
        {
        }

        public string Direccion { get; set; }

        public Cliente(string nombre, string username, string password, string direccion)
            : base(nombre, username, password)
        {
            Direccion = direccion;
        }
    }
}
