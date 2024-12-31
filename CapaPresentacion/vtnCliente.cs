using ClosedXML.Excel;
using System;
using Entidad;
using CapaNegocios;
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
    public partial class vtnCliente : Form
    {
        public vtnCliente()
        {
            InitializeComponent();
        }
        private void vtnCliente_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "En Espera" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "Atendiendo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            foreach(DataGridViewColumn columna in tablaCliente.Columns)
            {
                if(columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmbBuscar.Items.Add(new {Valor = columna.Name, Texto = columna.HeaderText});
                }
            }
            cmbBuscar.DisplayMember = "Texto";
            cmbBuscar.ValueMember = "Valor";
            cmbBuscar.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
            List<Cliente> mostrarCliente = new Negocios().moscliSQL();
            foreach(Cliente cliente in mostrarCliente)
            {
                tablaCliente.Rows.Add(new object[] {"", cliente.ID, cliente.Codigo, cliente.Nombres, cliente.Apellidos, cliente.Cedula, cliente.Telefono, cliente.CorreoElectronico, cliente.Estado == true ? 1 : 0, cliente.Estado == true ? "En Espera" : "Atendiendo" });
            }
            txtNombres.Select();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            Cliente agregarCliente = new Cliente(
                0, 
                txtCodigo.Text,
                txtNombres.Text,
                txtApellidos.Text,
                txtCedula.Text,
                txtTelefono.Text,
                txtCorreoElectronico.Text,
                valorCmbEstado == 1
            );

            int idClienteIngresado = new Negocios().regcliSQL(agregarCliente, out mensaje);
            if (idClienteIngresado == 0)
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idClienteIngresado != 0)
                {
                    if (selectedItemCmbEstado != null)
                    {
                        tablaCliente.Rows.Add(new object[] { "", idClienteIngresado, txtCodigo.Text, txtNombres.Text, txtApellidos.Text, txtCedula.Text, txtTelefono.Text, txtCorreoElectronico.Text, valorCmbEstado, textoCmbEstado });
                        MessageBox.Show("El cliente fue agregado correctamente.", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Cliente");
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
            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje;

            Cliente clienteModificado = new Cliente(
                Convert.ToInt32(txtID.Text),
                txtCodigo.Text,
                txtNombres.Text,
                txtApellidos.Text,
                txtCedula.Text,
                txtTelefono.Text,
                txtCorreoElectronico.Text,
                valorCmbEstado == 1
            );

            bool modificar = new Negocios().edicliSQL(clienteModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El cliente fue modificado correctamente.", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txtIndice.Text);
                tablaCliente.Rows[indice].Cells["ID"].Value = clienteModificado.ID;
                tablaCliente.Rows[indice].Cells["Codigo"].Value = clienteModificado.Codigo;
                tablaCliente.Rows[indice].Cells["Nombre"].Value = clienteModificado.Nombres;
                tablaCliente.Rows[indice].Cells["Apellidos"].Value = clienteModificado.Apellidos;
                tablaCliente.Rows[indice].Cells["Cedula"].Value = clienteModificado.Cedula;
                tablaCliente.Rows[indice].Cells["Telefono"].Value = clienteModificado.Telefono;
                tablaCliente.Rows[indice].Cells["CorreoElectronico"].Value = clienteModificado.CorreoElectronico;
                tablaCliente.Rows[indice].Cells["EstadoValor"].Value = clienteModificado.Estado ? 1 : 0;
                tablaCliente.Rows[indice].Cells["Estado"].Value = clienteModificado.Estado ? "En Espera" : "Atendiendo";
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
            {
                MessageBox.Show("Primero debe selecionar un cliente en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txtID.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este cliente?", "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Cliente clienteEliminado = new Cliente(
                            Convert.ToInt32(txtID.Text),
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            false
                        );

                        bool respuesta = new Negocios().elicliSQL(clienteEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaCliente.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                            MessageBox.Show("El cliente fue eliminado correctamente.", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if(tablaCliente.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaCliente.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaCliente.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[9].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Listado_Clientes.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Clientes");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(guardar.FileName);
                        MessageBox.Show("Excel generado correctamente.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el Excel.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmbBuscar = cmbBuscar.SelectedItem;
            string valorCmbBuscar = selectedItemCmbBuscar.Valor;
            string columnaFiltro = valorCmbBuscar.ToString();
            int filasVisibles = 0;

            foreach (DataGridViewRow fila in tablaCliente.Rows)
            {
                if (fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                {
                    fila.Visible = true;
                    filasVisibles++;
                }
                else
                {
                    fila.Visible = false;
                }
            }
            if (filasVisibles == 0)
            {
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscar.Text = " ";
                foreach (DataGridViewRow fila in tablaCliente.Rows)
                {
                    fila.Visible = true;
                }
            }
        }
        public void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtCodigo.Text = "";
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtCorreoElectronico.Clear();
            cmbEstado.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
        }

        private void tablaCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaCliente.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "En Espera")
                {
                    DataGridViewRow row = tablaCliente.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
            }
        }
        private void tablaCliente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCliente.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = tablaCliente.Rows[indice].Cells["ID"].Value.ToString();
                    txtCodigo.Text = tablaCliente.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombres.Text = tablaCliente.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtApellidos.Text = tablaCliente.Rows[indice].Cells["Apellidos"].Value.ToString();
                    txtCedula.Text = tablaCliente.Rows[indice].Cells["Cedula"].Value.ToString();
                    txtTelefono.Text = tablaCliente.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtCorreoElectronico.Text = tablaCliente.Rows[indice].Cells["CorreoElectronico"].Value.ToString();

                    foreach (dynamic item in cmbEstado.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if (valor == Convert.ToInt32(tablaCliente.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_cmbEstado = cmbEstado.Items.IndexOf(item);
                            cmbEstado.SelectedIndex = indice_cmbEstado;
                            break;
                        }
                    }
                }
            }
        }

        private string GenerarCodigo(int longitud)
        {
            const string caraceres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random randon = new Random();
            char[] resultado = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                resultado[i] = caraceres[randon.Next(caraceres.Length)];
            }
            return new string (resultado);
        }

        private void tablaCliente_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Apellidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Cédula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if (txtCedula.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("El campo Cédula debe contener exactamente 10 números.", "Campo Cédula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if (txtTelefono.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("El campo Telefono debe contener exactamente 10 números.", "Campo Cédula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
