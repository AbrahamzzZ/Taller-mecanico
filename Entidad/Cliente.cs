using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente : Persona
    {
        public bool Estado { get; set; }

        public Cliente() : base(0, "", "", "", "", "", "")
        {

        }

        public Cliente(int id, string codigo, string nombres, string apellidos, string cedula, string telefono, string correoElectronico, bool estado)
            : base(id, codigo, nombres, apellidos, cedula, telefono, correoElectronico)
        {
            Estado = estado;
        }


    }
}
