using CapaNegocios;
using ClosedXML.Excel;
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
    public partial class vtnServicio : Form
    {
        public vtnServicio()
        {
            InitializeComponent();
        }

        private void vtnServicio_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in tablaServicio.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmbBuscar.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbBuscar.DisplayMember = "Texto";
            cmbBuscar.ValueMember = "Valor";
            cmbBuscar.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
            List<Servicio> mostrarServicio = new Negocios().mosserSQL();
            foreach (Servicio servicios in mostrarServicio)
            {
                tablaServicio.Rows.Add(new object[] { "", servicios.ID, servicios.Codigo, servicios.Nombre, servicios.Precio, servicios.Estado == true ? 1 : 0, servicios.Estado == true ? "Activo" : "No Activo" });
            }
            txtNombre.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) mensaje += "- Es necesario el nombre del servicio.\n";
                if (string.IsNullOrWhiteSpace(txtPrecio.Text)) mensaje += "- Es necesario el precio del servicio.";
                MessageBox.Show(mensaje, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Servicio agregarServicio = new Servicio()
                {
                    ID = Convert.ToInt32(txtID.Text),
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    Estado = valorCmbEstado == 1
                };

                int idServicioIngresado = new Negocios().regserSQL(agregarServicio, out mensaje);
                if (idServicioIngresado == 0)
                {
                    MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (idServicioIngresado != 0)
                    {
                        // Verificar si los elementos seleccionados no son nulos
                        if (selectedItemCmbEstado != null)
                        {
                            tablaServicio.Rows.Add(new object[] { "", idServicioIngresado, txtCodigo.Text, txtNombre.Text, txtPrecio.Text, valorCmbEstado, textoCmbEstado });
                            MessageBox.Show("El servicio fue agregado correctamente.", "Agregar servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Servicio");
                        }
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

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio)) ;

            Servicio ServicioModificado = new Servicio()
            {
                ID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Precio = precio,
                Estado = valorCmbEstado == 1
            };
            bool modificar = new Negocios().ediserSQL(ServicioModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El servicio fue modificado correctamente.", "Modificar servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txtIndice.Text);
                tablaServicio.Rows[indice].Cells["ID"].Value = ServicioModificado.ID;
                tablaServicio.Rows[indice].Cells["Codigo"].Value = ServicioModificado.Codigo;
                tablaServicio.Rows[indice].Cells["Nombre"].Value = ServicioModificado.Nombre;
                tablaServicio.Rows[indice].Cells["Precio"].Value = ServicioModificado.Precio;
                tablaServicio.Rows[indice].Cells["EstadoValor"].Value = ServicioModificado.Estado ? 1 : 0;
                tablaServicio.Rows[indice].Cells["Estado"].Value = ServicioModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Primero debe selecionar un servicio en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txtID.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este servicio?", "Eliminar servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Servicio servicioEliminado = new Servicio()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                        };
                        bool respuesta = new Negocios().eliserSQL(servicioEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaServicio.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                            MessageBox.Show("El servicio fue eliminado correctamente.", "Eliminar servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        public void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Clear();
            txtPrecio.Clear();
            cmbEstado.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaServicio.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaServicio.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaServicio.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[6].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Listado_Servicios.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Servicios");
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

            foreach (DataGridViewRow fila in tablaServicio.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscar.Text = " ";
                foreach (DataGridViewRow fila in tablaServicio.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void tablaServicio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaServicio.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaServicio.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaServicio.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = tablaServicio.Rows[indice].Cells["ID"].Value.ToString();
                    txtCodigo.Text = tablaServicio.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = tablaServicio.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtPrecio.Text = tablaServicio.Rows[indice].Cells["Precio"].Value.ToString();

                    foreach (dynamic item in cmbEstado.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if (valor == Convert.ToInt32(tablaServicio.Rows[indice].Cells["EstadoValor"].Value))
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
            return new string(resultado);
        }

        private void tablaServicio_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
