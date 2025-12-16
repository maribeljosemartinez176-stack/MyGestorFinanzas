using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Core.Utilidades
{
    public static class Validador
    {
        public static bool EsTextoValido(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }

        public static bool EsNumeroValido(int numero)
        {
            return numero > 0;
        }

        public static bool EsPasswordValido(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

    }
}
