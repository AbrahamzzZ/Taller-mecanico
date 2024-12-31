using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Tecnico : Persona
    {
        public string Especializacion { get; set; }
        public int Anios_Experiencia { get; set; }
        public bool Estado { get; set; }

        public Tecnico() : base(0, "", "", "", "", "", "") { 

        }
        public Tecnico(int id, string codigo, string nombres, string apellidos, string cedula, string telefono, string correoElectronico, string especializacion, int aniosExperiencia, bool estado)
            : base(id, codigo, nombres, apellidos, cedula, telefono, correoElectronico)
        {

            Especializacion = especializacion;
            Anios_Experiencia = aniosExperiencia;
            Estado = estado;
        }
    }
}
