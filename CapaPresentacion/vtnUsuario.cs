using CapaNegocios;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class vtnUsuario : Form
    {
        private static int ultimoCodigoGenerado = 0;
        public vtnUsuario()
        {
            InitializeComponent();
        }

        private void vtnUsuarios_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;
            List<Rol> listaRol = new Negocios().lisrolSQL();
            foreach (Rol rol in listaRol)
            {
                cmbRol.Items.Add(new { Valor = rol.ID, Texto = rol.Descripcion });
            }
            cmbRol.DisplayMember = "Texto";
            cmbRol.ValueMember = "Valor";
            cmbRol.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in tablaUsuario.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbBuscar.DisplayMember = "Texto";
            cmbBuscar.ValueMember = "Valor";
            cmbBuscar.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(4);
            List<Usuario> mostrarUsuario = new Negocios().mosusuSQL();
            foreach (Usuario usuarios in mostrarUsuario)
            {
                tablaUsuario.Rows.Add(new object[] { "", usuarios.ID, usuarios.Codigo, usuarios.NombreCompleto, usuarios.CorreoElectronico, usuarios.Clave, usuarios.oRol.ID, usuarios.oRol.Descripcion, usuarios.Estado == true ? 1 : 0, usuarios.Estado == true ? "Activo" : "No Activo" });
            }
            txtNombreCompleto.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectItemCmbRol = cmbRol.SelectedItem;
            int valorCmbRol = selectItemCmbRol.Valor;
            string textoCmbRol = selectItemCmbRol.Texto;

            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            Usuario agregarUsuario = new Usuario()
            {
                ID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                NombreCompleto = txtNombreCompleto.Text,
                CorreoElectronico = txtCorreoElectronico.Text,
                Clave = txtClave.Text,
                oRol = new Rol { ID = valorCmbRol },
                Estado = valorCmbEstado == 1
            };

            int idUsuarioIngresado = new Negocios().regusuSQL(agregarUsuario, out mensaje);
            if (idUsuarioIngresado == 0)
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idUsuarioIngresado != 0)
                {
                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmbEstado != null)
                    {
                        tablaUsuario.Rows.Add(new object[] { "", idUsuarioIngresado, txtCodigo.Text, txtNombreCompleto.Text, txtCorreoElectronico.Text, txtClave.Text, valorCmbEstado, textoCmbRol, valorCmbEstado, textoCmbEstado });
                        MessageBox.Show("El usuario fue agregado correctamente.", "Agregar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Repuesto");
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            dynamic selectItemCmbRol = cmbRol.SelectedItem;
            int valorCmbRol = selectItemCmbRol.Valor;
            string textoCmbRol = selectItemCmbRol.Texto;

            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            Usuario usuarioModificado = new Usuario()
            {
                ID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                NombreCompleto = txtNombreCompleto.Text,
                CorreoElectronico = txtCorreoElectronico.Text,
                Clave = txtClave.Text,
                oRol = new Rol { ID = valorCmbRol },
                Estado = valorCmbEstado == 1
            };
            bool modificar = new Negocios().ediusuSQL(usuarioModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El usuario fue modificado correctamente.", "Modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int indice = Convert.ToInt32(txtIndice.Text);
                tablaUsuario.Rows[indice].Cells["Codigo"].Value = usuarioModificado.Codigo;
                tablaUsuario.Rows[indice].Cells["NombresCompleto"].Value = usuarioModificado.NombreCompleto;
                tablaUsuario.Rows[indice].Cells["CorreoElectronico"].Value = usuarioModificado.CorreoElectronico;
                tablaUsuario.Rows[indice].Cells["Clave"].Value = usuarioModificado.Clave;
                tablaUsuario.Rows[indice].Cells["IdRol"].Value = usuarioModificado.oRol.ID;
                tablaUsuario.Rows[indice].Cells["Rol"].Value = textoCmbRol;
                tablaUsuario.Rows[indice].Cells["EstadoValor"].Value = usuarioModificado.Estado ? 1 : 0;
                tablaUsuario.Rows[indice].Cells["Estado"].Value = usuarioModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al modificar la información del usuario: " + mensaje, "Modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text) || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Primero debe selecionar un usuario en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int idUsuario = Convert.ToInt32(txtID.Text);
                if (idUsuario == 1)
                {
                    MessageBox.Show("No se puede eliminar el primer usuario porque es necesario para el acceso al sistema.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar este usuario?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Usuario usuarioEliminado = new Usuario()
                        {
                            ID = idUsuario,
                        };
                        bool respuesta = new Negocios().eliusuSQL(usuarioEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaUsuario.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                            MessageBox.Show("El usuario fue eliminado correctamente.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        public void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtNombreCompleto.Clear();
            txtCorreoElectronico.Clear();
            txtClave.Clear();
            txtCodigo.Clear();
            txtCodigo.Text = GenerarCodigo(4);
            cmbRol.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private string GenerarCodigo(int longitud)
        {
            const string caraceres = "0123456789";
            Random randon = new Random();
            char[] resultado = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                resultado[i] = caraceres[randon.Next(caraceres.Length)];
            }
            return new string(resultado);
        }
        private void tablaUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaUsuario.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaUsuario.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaUsuario.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = tablaUsuario.Rows[indice].Cells["ID"].Value.ToString();
                    txtCodigo.Text = tablaUsuario.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombreCompleto.Text = tablaUsuario.Rows[indice].Cells["NombresCompleto"].Value.ToString();
                    txtCorreoElectronico.Text = tablaUsuario.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    txtClave.Text = tablaUsuario.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (dynamic item in cmbRol.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUsuario.Rows[indice].Cells["IDROL"].Value))
                        {
                            int indice_cmb = cmbRol.Items.IndexOf(item);
                            cmbRol.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                    foreach (dynamic item in cmbEstado.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;

                        if (valor == Convert.ToInt32(tablaUsuario.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmb = cmbEstado.Items.IndexOf(item);
                            cmbEstado.SelectedIndex = indice_cmb;
                            break;
                        }
                    }
                }
            }
        }

        private void tablaUsuario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var p = Properties.Resources.visto.Width;
                var q = Properties.Resources.visto.Height;
                var r = e.CellBounds.Left + (e.CellBounds.Width - p) / 2;
                var s = e.CellBounds.Top + (e.CellBounds.Height - q) / 2;
                e.Graphics.DrawImage(Properties.Resources.visto, new Rectangle(r, s, p, q));
                e.Handled = true;
            }
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombres Completos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
