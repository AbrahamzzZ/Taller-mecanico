using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Repuesto
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}
