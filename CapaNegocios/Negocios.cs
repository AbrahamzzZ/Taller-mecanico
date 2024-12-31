using CapaDatos;
using Entidad;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class Negocios
    {
        private Datos objeto = new Datos();
        //Login
        public List<Usuario> ListarUsuarios()
        {
            return objeto.ingresarUsuario();
        }
        public Usuario recclaSQL(string correo)
        {
            return objeto.recuperarContrasena(correo);
        }
        //Permiso
        public List<Permiso> permeSQL(int idUsuario)
        {
            return objeto.permisosMenu(idUsuario);
        }
        //Rol
        public List<Rol> lisrolSQL()
        {
            return objeto.listarRol();
        }
        //Usuario
        public List<Usuario> mosusuSQL()
        {
            return objeto.mostrarUsuario();
        }
        public int regusuSQL(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                Mensaje += "- Es necesario el nombre completo del usuario.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje += "- Es necesario el correo electrónico del usuario.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Clave))
            {
                Mensaje += "- Es necesario la clave del usuario.";
            }
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }
            else
            {
                return objeto.registrarUsuario(obj, out Mensaje);
            }
        }
        public bool ediusuSQL(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el nombre completo del usuario.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "Es necesario el correo electrónico del usuario.\n";
            }
            if (obj.Clave == "")
            {
                mensaje += "Es necesario la clave del usuario.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto.editarUsuario(obj, out mensaje);
            }
        }
        public bool eliusuSQL(Usuario obj, out string Mensaje)
        {
            return objeto.eliminarUsuario(obj, out Mensaje);
        }
        //Cliente
        public List<Cliente> moscliSQL()
        {
            return objeto.mostrarCliente();
        }
        public int regcliSQL(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje += "- Es necesario los dos nombres del cliente.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje += "- Es necesario los dos apellidos del cliente.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Cedula))
            {
                Mensaje += "- Es necesario la cédula del cliente.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje += "- Es necesario el teléfono del cliente.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje += "- Es necesario el correo electrónico del cliente.";
            }
            if(!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }
            else
            {
                return objeto.registrarCliente(obj, out Mensaje);
            }
        }
        public bool edicliSQL(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombres == "")
            {
                mensaje += "- Es necesario los dos nombres del cliente.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "- Es necesario los dos apellidos del cliente.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "- Es necesario la cédula del cliente.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "- Es necesario el teléfono del cliente.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "- Es necesario el correo electrónico del cliente.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto.editarCliente(obj, out mensaje);
            }
        }
        public bool edicliestSQL(int idCliente, bool estado)
        {
            return objeto.actualizarEstadoCliente(idCliente, estado);
        }
        public bool elicliSQL(Cliente obj, out string mensaje)
        {
            return objeto.eliminarCliente(obj, out mensaje);
        }
        //Tecnico
        public List<Tecnico> mostecSQL()
        {
            return objeto.mostrarTecnico();
        }
        public int regtecSQL(Tecnico obj, out string Mensaje)
        {
            return objeto.registrarTecnico(obj, out Mensaje);
        }
        public bool editecSQL(Tecnico obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombres == "")
            {
                mensaje += "- Es necesario los dos nombres del técnico.\n";
            }
            if (obj.Apellidos == "")
            {
                mensaje += "- Es necesario los dos apellidos del técnico.\n";
            }
            if (obj.Cedula == "")
            {
                mensaje += "- Es necesario la cédula del técnico.\n";
            }
            if (obj.Telefono == "")
            {
                mensaje += "- Es necesario el teléfono del técnico.\n";
            }
            if (obj.CorreoElectronico == "")
            {
                mensaje += "- Es necesario el correo electrónico del técnico.\n";
            }
            if (obj.Especializacion == "")
            {
                mensaje += "- Es necesaria la especialización del técnico.\n";
            }
            if (obj.Anios_Experiencia == 0)
            {
                mensaje += "- Es necesario los años de experiencia del técnico.";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto.editarTecnico(obj, out mensaje);
            }
        }
        public bool editecestSQL(int idTecnico, bool estado)
        {
            return objeto.actualizarEstadoTecnico(idTecnico, estado);
        }
        public bool elitecSQL(Tecnico obj, out string mensaje)
        {
            return objeto.eliminarTecnico(obj, out mensaje);
        }
        //Celular
        public List<Celular> moscelSQL()
        {
            return objeto.mostrarCelular();
        }
        public int regcelSQL(Celular obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(obj.Marca))
            {
                Mensaje += "- Es necesario la marca del celular.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Modelo))
            {
                Mensaje += "- Es necesario el modelo del celular.";
            }
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }
            else
            {
                return objeto.registrarCelular(obj, out Mensaje);
            }
        }
        public bool edicelSQL(Celular obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Marca == "")
            {
                mensaje += "- Es necesario la marca del celular.\n";
            }
            if (obj.Modelo == "")
            {
                mensaje += "- Es necesario el modelo del celular.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto.editarCelular(obj, out mensaje);
            }
        }
        public bool edicelestSQL(int idCelular, bool estado)
        {
            return objeto.actualizarEstadoCelular(idCelular, estado);
        }
        public bool elicelSQL(Celular obj, out string mensaje)
        {
            return objeto.eliminarCelular(obj, out mensaje);
        }
        //Repuesto
        public List<Repuesto> mosrepuSQL()
        {
            return objeto.mostrarRepuesto();
        }
        public int regrepuSQL(Repuesto obj, out string Mensaje)
        {
            return objeto.registrarRepuesto(obj, out Mensaje);
        }
        public bool edirepuSQL(Repuesto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                mensaje += "- Es necesario el nombre del repuesto.\n";
            }
            if (obj.Stock == 0)
            {
                mensaje += "- Es necesario la cantidad del repuestos a ingresar.\n";
            }
            if (obj.Precio == 0)
            {
                mensaje += "- Es necesario el precio del repuestos.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto.editarRepuesto(obj, out mensaje);
            }
        }
        public bool elirepuSQL(Repuesto obj, out string mensaje)
        {
            return objeto.eliminarRepuesto(obj, out mensaje);
        }
        //Servicio
        public List<Servicio> mosserSQL()
        {
            return objeto.mostrarServicio();
        }
        public int regserSQL(Servicio obj, out string Mensaje)
        {
            return objeto.registrarServicio(obj, out Mensaje);
        }
        public bool ediserSQL(Servicio obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                mensaje += "- Es necesario el nombre del servicio.\n";
            }
            if (obj.Precio == 0)
            {
                mensaje += "- Es necesario el precio del servicio.\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto.editarServicio(obj, out mensaje);
            }
        }
        public bool eliserSQL(Servicio obj, out string mensaje)
        {
            return objeto.eliminarServicio(obj, out mensaje);
        }
        //Reparacion
        public int regrepSQL(Reparacion obj, out string Mensaje)
        {
            return objeto.registrarReparacion(obj, out Mensaje);
        }
        //Detalle reparacion
        public Reparacion obtrepSQL(string codigo)
        {
            return objeto.obtenerReparacionPorCodigo(codigo);
        }
    }
}
