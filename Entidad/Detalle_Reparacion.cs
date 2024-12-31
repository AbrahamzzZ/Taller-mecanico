using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Detalle_Reparacion
    {
        public int ID { get; set; }
        public Reparacion oReparacion { get; set; }
        public List<Repuesto> Repuestos { get; set; }
        public decimal valorTotalRepuestos {  get; set; }
        public decimal valorTotalServicio {  get; set; }
    }
}
