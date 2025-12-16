using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Core.Seguridad
{
    public class AuthSingleton
    {
        private static AuthSingleton instancia;
        public string UsuarioActual { get; private set; }

        private AuthSingleton() { }

        public static AuthSingleton Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new AuthSingleton();

                return instancia;
            }
        }

        public void Login(string usuario)
        {
            UsuarioActual = usuario;
        }

        public void Logout()
        {
            UsuarioActual = null;
        }

        public bool EstaLogueado()
        {
            return UsuarioActual != null;
        }
    }
}
