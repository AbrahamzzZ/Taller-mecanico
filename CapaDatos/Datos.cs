using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entidad;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class Datos
    {
        /// <summary>
        /// Metodo para la conexion
        /// </summary>
        /// <returns>La conexion de la base de datos</returns>
        public SqlConnection ConexionBDD()
        {
            SqlConnection cn = new SqlConnection("server= DESKTOP-8CQM9OG\\SQLSEXPRESS ; database= ProyectoGrupo7 ; integrated security=true;");//Conexion BD
            cn.Open();
            return cn;
        }
        /// <summary>
        /// Metodo que muestra un lista de todos los usuarios 
        /// </summary>
        /// <returns>Una lista de todos los usuarios</returns>
        public List<Usuario> IngresarUsuario()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            try
            {
                string registrar = "SELECT ID, CODIGO, NOMBRE_COMPLETO, CORREO_ELECTRONICO, CLAVE, ESTADO FROM USUARIO";
                SqlCommand cmd = new SqlCommand(registrar, ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaUsuario.Add(new Usuario()
                    {
                        ID = Convert.ToInt32(leer["ID"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Clave = leer["CLAVE"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception us)
            {
                listaUsuario = new List<Usuario>();
            }
            return listaUsuario;
        }
        public Usuario RecuperarContrasena(string correoElectronico)
        {
            Usuario usuario = null;
            try
            {
                string consulta = "SELECT CLAVE FROM USUARIO WHERE CORREO_ELECTRONICO = @correoElectronico";
                SqlCommand cmd = new SqlCommand(consulta, ConexionBDD());
                cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                if (leer.Read())
                {
                    usuario = new Usuario()
                    {
                        Clave = leer["CLAVE"].ToString()
                    };
                }
            }
            catch (Exception us)
            {

            }
            return usuario;
        }
        //Usuario
        public List<Usuario> mostrarUsuario()
        {
            List<Usuario> listaMostrarUsuario = new List<Usuario>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT u.ID, u.CODIGO, u.NOMBRE_COMPLETO, u.CORREO_ELECTRONICO, u.CLAVE, u.ESTADO, r.ID[ID_ROL], r.DESCRIPCION FROM USUARIO u");
                mostrar.AppendLine("inner join ROL r on r.ID = u.ID_ROL");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarUsuario.Add(new Usuario()
                    {
                        ID = Convert.ToInt32(leer["ID"]),
                        Codigo = leer["CODIGO"].ToString(),
                        NombreCompleto = leer["NOMBRE_COMPLETO"].ToString(),
                        CorreoElectronico = leer["CORREO_ELECTRONICO"].ToString(),
                        Clave = leer["CLAVE"].ToString(),
                        Estado = Convert.ToBoolean(leer["ESTADO"]),
                        oRol = new Rol() { ID = Convert.ToInt32(leer["ID"]), Descripcion = leer["DESCRIPCION"].ToString() },
                    });
                }
            }
            catch (Exception us)
            {
                listaMostrarUsuario = new List<Usuario>();
            }
            return listaMostrarUsuario;
        }
        public int registrarUsuario(Usuario obj, out string mensaje)
        {
            int idUsuarioGenerado = 0;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_USUARIO", ConexionBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Completo", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                cmd.Parameters.AddWithValue("Id_Rol", obj.oRol.ID);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                idUsuarioGenerado = 0;
                mensaje = us.Message;

            }
            return idUsuarioGenerado;
        }
        public bool editarUsuario(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_EDITAR_USUARIO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Completo", obj.NombreCompleto);
                cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Clave", obj.Clave);
                cmd.Parameters.AddWithValue("Id_Rol", obj.oRol.ID);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                respuesta = false;
                mensaje = us.Message;

            }
            return respuesta;
        }
        public bool eliminarUsuario(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_USUARIO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception us)
            {
                respuesta = false;
                mensaje = us.Message;

            }
            return respuesta;
        }
        //Permiso
        public List<Permiso> permisosMenu(int idusuario)
        {
            List<Permiso> listaPermiso = new List<Permiso>();
            try
            {
                StringBuilder permisos = new StringBuilder();
                permisos.AppendLine("SELECT p.ID_ROL, p.NOMBRE_MENU FROM PERMISO p");
                permisos.AppendLine("inner join ROL r on r.ID = p.ID_ROL");
                permisos.AppendLine("inner join USUARIO u on u.ID_ROL = r.ID"); 
                permisos.AppendLine("WHERE u.ID = @id");
                SqlCommand cmd = new SqlCommand(permisos.ToString(), ConexionBDD());
                cmd.Parameters.AddWithValue("@id", idusuario);
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaPermiso.Add(new Permiso()
                    {
                        oRol = new Rol() { ID = Convert.ToInt32(leer["ID_ROL"]) },
                        NombreMenu = leer["NOMBRE_MENU"].ToString(),
                    });
                }
            }
            catch (Exception pe)
            {
                listaPermiso = new List<Permiso>();
            }
            return listaPermiso;
        }
        //Rol
        public List<Rol> listarRol()
        {
            List<Rol> listaRoles = new List<Rol>();
            try
            {
                StringBuilder rol = new StringBuilder();
                rol.AppendLine("SELECT ID, DESCRIPCION FROM ROL");
                SqlCommand cmd = new SqlCommand(rol.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaRoles.Add(new Rol()
                    {
                        ID = Convert.ToInt32(leer["ID"]),
                        Descripcion = leer["DESCRIPCION"].ToString(),
                    }); ;
                }
            }
            catch (Exception ro)
            {
                listaRoles = new List<Rol>();
            }
            return listaRoles;
        }
        //Cliente
        public List<Cliente> mostrarCliente()
        {
            List<Cliente> listaMostrarCliente = new List<Cliente>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID, CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESTADO FROM CLIENTE;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarCliente.Add(new Cliente(
                        Convert.ToInt32(leer["ID"]),
                        leer["CODIGO"].ToString(),
                        leer["NOMBRES"].ToString(),
                        leer["APELLIDOS"].ToString(),
                        leer["CEDULA"].ToString(),
                        leer["TELEFONO"].ToString(),
                        leer["CORREO_ELECTRONICO"].ToString(),
                        Convert.ToBoolean(leer["ESTADO"])
                    ));
                }
            }
            catch (Exception cl)
            {
                listaMostrarCliente = new List<Cliente>();
            }
            return listaMostrarCliente;
        }

        public int registrarCliente(Cliente obj, out string Mensaje)
        {
            int idClienteGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_CLIENTE", ConexionBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Cliente", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idClienteGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                idClienteGenerado = 0;
                Mensaje = cl.Message;
            }
            return idClienteGenerado;
        }

        public bool editarCliente (Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_CLIENTE", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Cliente", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception cl)
            {
                respuesta = false;
                mensaje = cl.Message;
            }
            return respuesta;
        }
        public bool actualizarEstadoCliente(int idCliente, bool estado)
        {
            try
            {
                StringBuilder actualizar = new StringBuilder();
                actualizar.AppendLine("UPDATE CLIENTE SET ESTADO = @ESTADO WHERE ID = @ID;");
                SqlCommand cmd = new SqlCommand(actualizar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ESTADO", estado);
                cmd.Parameters.AddWithValue("@ID", idCliente);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarCliente(Cliente obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_CLIENTE", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception pr)
            {
                respuesta = false;
                mensaje = pr.Message;
            }
            return respuesta;
        }
        //Tecnico
        public List<Tecnico> mostrarTecnico()
        {
            List<Tecnico> listaMostrarTecnico = new List<Tecnico>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID, CODIGO, NOMBRES, APELLIDOS, CEDULA, TELEFONO, CORREO_ELECTRONICO, ESPECIALIZACION, ANIOS_EXPERIENCIA, ESTADO FROM TECNICO;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarTecnico.Add(new Tecnico(
                        Convert.ToInt32(leer["ID"]),
                        leer["CODIGO"].ToString(),
                        leer["NOMBRES"].ToString(),
                        leer["APELLIDOS"].ToString(),
                        leer["CEDULA"].ToString(),
                        leer["TELEFONO"].ToString(),
                        leer["CORREO_ELECTRONICO"].ToString(),
                        leer["ESPECIALIZACION"].ToString(),
                        Convert.ToInt32(leer["ANIOS_EXPERIENCIA"]),
                        Convert.ToBoolean(leer["ESTADO"])
                    ));
                }
            }
            catch (Exception ex)
            {
                listaMostrarTecnico = new List<Tecnico>();
            }
            return listaMostrarTecnico;
        }
        
        public int registrarTecnico(Tecnico obj, out string Mensaje)
        {
            int idTecnicoGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_TECNICO", ConexionBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Tecnico", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Tecnico", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Especializacion", obj.Especializacion);
                cmd.Parameters.AddWithValue("Anios_Experiencia", obj.Anios_Experiencia);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idTecnicoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception te)
            {
                idTecnicoGenerado = 0;
                Mensaje = te.Message;
            }
            return idTecnicoGenerado;
        }
        public bool editarTecnico(Tecnico obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_TECNICO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre_Tecnico", obj.Nombres);
                cmd.Parameters.AddWithValue("Apellido_Tecnico", obj.Apellidos);
                cmd.Parameters.AddWithValue("Cedula", obj.Cedula);
                cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("Correo_Electronico", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("Especializacion", obj.Especializacion);
                cmd.Parameters.AddWithValue("Anios_Experiencia", obj.Anios_Experiencia);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception te)
            {
                respuesta = false;
                mensaje = te.Message;
            }
            return respuesta;
        }
        public bool actualizarEstadoTecnico(int idTecnico, bool estado)
        {
            try
            {
                StringBuilder actualizar = new StringBuilder();
                actualizar.AppendLine("UPDATE TECNICO SET ESTADO = @ESTADO WHERE ID = @ID;");
                SqlCommand cmd = new SqlCommand(actualizar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ESTADO", estado);
                cmd.Parameters.AddWithValue("@ID", idTecnico);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarTecnico(Tecnico obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_TECNICO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception te)
            {
                respuesta = false;
                mensaje = te.Message;
            }
            return respuesta;
        }
        //Celular
        
        public List<Celular> mostrarCelular()
        {
            List<Celular> listaMostrarCelular = new List<Celular>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT c.ID, c.CODIGO, c.MARCA, c.MODELO, c.ID_CLIENTE, cl.NOMBRES, c.ESTADO FROM CELULAR c");
                mostrar.AppendLine("inner join CLIENTE cl on cl.ID = c.ID_CLIENTE;");

                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();

                while (leer.Read())
                {
                    int clienteId = Convert.ToInt32(leer["ID_CLIENTE"]);
                    string clienteNombres = leer["NOMBRES"].ToString();

                    Cliente cliente = new Cliente(clienteId, "", clienteNombres, "", "", "", "", true);

                    listaMostrarCelular.Add(new Celular()
                    {
                        ID = Convert.ToInt32(leer["ID"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Marca = leer["MARCA"].ToString(),
                        Modelo = leer["MODELO"].ToString(),
                        oCliente = cliente,
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception ce)
            {
                listaMostrarCelular = new List<Celular>();
            }

            return listaMostrarCelular;
        }

        public int registrarCelular(Celular obj, out string Mensaje)
        {
            int idCelularGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_CELULAR", ConexionBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Marca", obj.Marca);
                cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.ID);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idCelularGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ce)
            {
                idCelularGenerado = 0;
                Mensaje = ce.Message;
            }
            return idCelularGenerado;
        }
        public bool editarCelular(Celular obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_CELULAR", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Marca", obj.Marca);
                cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.ID);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception te)
            {
                respuesta = false;
                mensaje = te.Message;
            }
            return respuesta;
        }
        public bool actualizarEstadoCelular(int idCelular, bool estado)
        {
            try
            {
                StringBuilder actualizar = new StringBuilder();
                actualizar.AppendLine("UPDATE CELULAR SET ESTADO = @ESTADO WHERE ID = @ID;");
                SqlCommand cmd = new SqlCommand(actualizar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ESTADO", estado);
                cmd.Parameters.AddWithValue("@ID", idCelular);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarCelular(Celular obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_CELULAR", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ce)
            {
                respuesta = false;
                mensaje = ce.Message;
            }
            return respuesta;
        }
        //Repuesto
        public List<Repuesto> mostrarRepuesto()
        {
            List<Repuesto> listaMostrarRepuesto = new List<Repuesto>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID, CODIGO, NOMBRE, STOCK, PRECIO, ESTADO FROM REPUESTO;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarRepuesto.Add(new Repuesto()
                    {
                        ID = Convert.ToInt32(leer["ID"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombre = leer["NOMBRE"].ToString(),
                        Stock = Convert.ToInt32(leer["STOCK"].ToString()),
                        Precio = Convert.ToDecimal(leer["PRECIO"].ToString()),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception re)
            {
                listaMostrarRepuesto = new List<Repuesto>();
            }
            return listaMostrarRepuesto;
        }
       
        public int registrarRepuesto(Repuesto obj, out string Mensaje)
        {
            int idRepuestoGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_REPUESTO", ConexionBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Stock", obj.Stock);
                cmd.Parameters.AddWithValue("Precio", obj.Precio);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idRepuestoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception re)
            {
                idRepuestoGenerado = 0;
                Mensaje = re.Message;
            }
            return idRepuestoGenerado;
        }
        public bool editarRepuesto(Repuesto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_REPUESTO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Stock", obj.Stock);
                cmd.Parameters.AddWithValue("Precio", obj.Precio);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception re)
            {
                respuesta = false;
                mensaje = re.Message;
            }
            return respuesta;
        }
        public bool eliminarRepuesto(Repuesto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_REPUESTO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception re)
            {
                respuesta = false;
                mensaje = re.Message;
            }
            return respuesta;
        }

        //Servicio
        public List<Servicio> mostrarServicio()
        {
            List<Servicio> listaMostrarServicio = new List<Servicio>();
            try
            {
                StringBuilder mostrar = new StringBuilder();
                mostrar.AppendLine("SELECT ID, CODIGO, NOMBRE, PRECIO, ESTADO FROM SERVICIO;");
                SqlCommand cmd = new SqlCommand(mostrar.ToString(), ConexionBDD());
                cmd.CommandType = CommandType.Text;
                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    listaMostrarServicio.Add(new Servicio()
                    {
                        ID = Convert.ToInt32(leer["ID"]),
                        Codigo = leer["CODIGO"].ToString(),
                        Nombre = leer["NOMBRE"].ToString(),
                        Precio = Convert.ToDecimal(leer["PRECIO"].ToString()),
                        Estado = Convert.ToBoolean(leer["ESTADO"])
                    });
                }
            }
            catch (Exception se)
            {
                listaMostrarServicio = new List<Servicio>();
            }
            return listaMostrarServicio;
        }
        public int registrarServicio(Servicio obj, out string Mensaje)
        {
            int idServicioGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_REGISTRAR_SERVICIO", ConexionBDD());
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Precio", obj.Precio);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                idServicioGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception se)
            {
                idServicioGenerado = 0;
                Mensaje = se.Message;
            }
            return idServicioGenerado;
        }
        public bool editarServicio(Servicio obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_EDITAR_SERVICIO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Precio", obj.Precio);
                cmd.Parameters.AddWithValue("Estado", obj.Estado);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception se)
            {
                respuesta = false;
                mensaje = se.Message;
            }
            return respuesta;
        }
        public bool eliminarServicio(Servicio obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINAR_SERVICIO", ConexionBDD());
                cmd.Parameters.AddWithValue("Id", obj.ID);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception se)
            {
                respuesta = false;
                mensaje = se.Message;
            }
            return respuesta;
        }

        //Reparacion
        public int registrarReparacion(Reparacion obj, out string Mensaje)
        {
            int idReparacionGenerada = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("PA_REGISTRAR_REPARACION", ConexionBDD()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Id_Usuario", obj.oUsuario.ID);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Id_Cliente", obj.oCliente.ID);
                    cmd.Parameters.AddWithValue("Id_Tecnico", obj.oTecnico.ID);
                    cmd.Parameters.AddWithValue("Id_Celular", obj.oCelular.ID);
                    cmd.Parameters.AddWithValue("Id_Servicio", obj.oServicio.ID);
                    cmd.Parameters.AddWithValue("Estado_Reparacion", obj.Estado);

                    DataTable dtRepuestos = new DataTable();
                    dtRepuestos.Columns.Add("ID_REPUESTO", typeof(int));
                    dtRepuestos.Columns.Add("CANTIDAD", typeof(int));

                    foreach (var repuesto in obj.Repuestos)
                    {
                        dtRepuestos.Rows.Add(repuesto.ID, repuesto.Cantidad);
                    }

                    SqlParameter paramRepuestos = new SqlParameter();
                    paramRepuestos.ParameterName = "@Repuestos";
                    paramRepuestos.TypeName = "dbo.TipoRepuesto";
                    paramRepuestos.SqlDbType = SqlDbType.Structured;
                    paramRepuestos.Value = dtRepuestos;

                    cmd.Parameters.Add(paramRepuestos);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    idReparacionGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idReparacionGenerada = 0;
                Mensaje = ex.Message;
            }
            return idReparacionGenerada;
        }
        //Detalle reparacion
        public Reparacion obtenerReparacionPorCodigo(string codigo)
        {
            Reparacion oReparacion = null;
            try
            {
                StringBuilder obtener = new StringBuilder();
                obtener.AppendLine("SELECT R.ID[ID_REPARACION], U.NOMBRE_COMPLETO[NOMBRE_USUARIO], R.CODIGO[CODIGO_REPARACION], C.ID[ID_CLIENTE], C.CEDULA, C.NOMBRES[CLIENTE], T.ID[ID_TECNICO], T.CEDULA, T.NOMBRES[TECNICO], CE.ID[ID_CELULAR], CE.MARCA[MARCA_CELULAR], CE.MODELO[MODELO_CELULAR], S.ID[ID_SERVICIO], S.Nombre[SERVICIO], ");
                obtener.AppendLine("DR.VALOR_TOTAL_SERVICIO, RR.ID_REPUESTO, RP.Nombre[NOMBRE_REPUESTO], RR.CANTIDAD, RP.PRECIO, (RR.CANTIDAD * RP.PRECIO) [VALOR_TOTAL_REPUESTO], Convert(char(10), DR.FECHA_ENTREGA, 103) [FECHA_ENTREGA] FROM REPARACION R");
                obtener.AppendLine("INNER JOIN DETALLE_REPARACION DR ON R.ID = DR.ID_REPARACION");
                obtener.AppendLine("INNER JOIN USUARIO U ON R.ID_USUARIO = U.ID");
                obtener.AppendLine("INNER JOIN CLIENTE C ON R.ID_CLIENTE = C.ID");
                obtener.AppendLine("INNER JOIN TECNICO T ON R.ID_TECNICO = T.ID");
                obtener.AppendLine("INNER JOIN CELULAR CE ON R.ID_CELULAR = CE.ID");
                obtener.AppendLine("INNER JOIN SERVICIO S ON R.ID_SERVICIO = S.ID");
                obtener.AppendLine("INNER JOIN REPARACION_REPUESTO RR ON R.ID = RR.ID_REPARACION");
                obtener.AppendLine("INNER JOIN REPUESTO RP ON RR.ID_REPUESTO = RP.ID");
                obtener.AppendLine("WHERE R.CODIGO = @codigo");

                SqlCommand cmd = new SqlCommand(obtener.ToString(), ConexionBDD());
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.CommandType = CommandType.Text;

                SqlDataReader leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    if (oReparacion == null)
                    {
                        oReparacion = new Reparacion
                        {
                            ID = Convert.ToInt32(leer["ID_REPARACION"]),
                            oUsuario = new Usuario { NombreCompleto = leer["NOMBRE_USUARIO"].ToString() },
                            Codigo = leer["CODIGO_REPARACION"].ToString(),
                            oCliente = new Cliente { Nombres = leer["CLIENTE"].ToString(), Cedula = leer["CEDULA"].ToString(), ID = Convert.ToInt32(leer["ID_CLIENTE"]) },
                            oTecnico = new Tecnico { Nombres = leer["TECNICO"].ToString(), Cedula = leer["CEDULA"].ToString(), ID = Convert.ToInt32(leer["ID_TECNICO"]) },
                            oCelular = new Celular { Marca = leer["MARCA_CELULAR"].ToString(), Modelo = leer["MODELO_CELULAR"].ToString(), ID = Convert.ToInt32(leer["ID_CELULAR"]) },
                            oServicio = new Servicio { Nombre = leer["SERVICIO"].ToString(), Precio = Convert.ToDecimal(leer["PRECIO"]), ID = Convert.ToInt32(leer["ID_SERVICIO"]) },
                            Fecha_Registro = leer["FECHA_ENTREGA"].ToString(),
                            oDetalle_Reparacion = new List<Detalle_Reparacion>()
                        };
                    }

                    var detalle = new Detalle_Reparacion
                    {
                        oReparacion = oReparacion,
                        valorTotalRepuestos = Convert.ToDecimal(leer["VALOR_TOTAL_REPUESTO"]),
                        valorTotalServicio = Convert.ToDecimal(leer["VALOR_TOTAL_SERVICIO"]),
                        Repuestos = new List<Repuesto>()
                    };

                    detalle.Repuestos.Add(new Repuesto
                    {
                        ID = Convert.ToInt32(leer["ID_REPUESTO"]),
                        Nombre = leer["NOMBRE_REPUESTO"].ToString(),
                        Cantidad = Convert.ToInt32(leer["CANTIDAD"]),
                        Precio = Convert.ToDecimal(leer["PRECIO"])
                    });

                    oReparacion.oDetalle_Reparacion.Add(detalle);
                }
            }
            catch (Exception ex)
            {
                oReparacion = null;
            }
            return oReparacion;
        
        }
    }
}
