using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Persona
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Persona(int id, string codigo, string nombres, string apellidos, string cedula, string telefono, string correoElectronico)
        {
            ID = id;
            Codigo = codigo;
            Nombres = nombres;
            Apellidos = apellidos;
            Cedula = cedula;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
        }
    }
}
