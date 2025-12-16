using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Envio
{
    public class DireccionEnvio
    {
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CP { get; set; }
        public string Referencias { get; set; }

        public override string ToString()
        {
            return $"{Calle} #{Numero}, {Colonia}, {Ciudad}, {Estado}, CP {CP}\n" +
                   $" Referencias: {Referencias}";
        }
    }
}
