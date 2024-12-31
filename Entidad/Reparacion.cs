using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Reparacion
    {
        public int ID { get; set; }
        public Usuario oUsuario { get; set; }
        public string Codigo { get; set; }
        public Cliente oCliente { get; set; }
        public Tecnico oTecnico { get; set; }
        public Celular oCelular { get; set; }
        public List<Repuesto> Repuestos { get; set; } = new List<Repuesto>();
        public Servicio oServicio { get; set; }
        public List<Detalle_Reparacion> oDetalle_Reparacion {  get; set; }
        public bool Estado { get; set; }
        public string Fecha_Registro { get; set; }
    }
}
