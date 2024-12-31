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
    public partial class vtnRepuesto : Form
    {
        public vtnRepuesto()
        {
            InitializeComponent();
        }

        private void vtnRepuesto_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in tablaRepuesto.Columns)
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
            List<Repuesto> mostrarRepuesto = new Negocios().mosrepuSQL();
            foreach (Repuesto repuestos in mostrarRepuesto)
            {
                tablaRepuesto.Rows.Add(new object[] { "", repuestos.ID, repuestos.Codigo, repuestos.Nombre, repuestos.Stock, repuestos.Precio, repuestos.Estado == true ? 1 : 0, repuestos.Estado == true ? "Activo" : "No Activo" });
            }
            txtNombre.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) mensaje += "- Es necesario el nombre del repuesto.\n";
                if (string.IsNullOrWhiteSpace(txtCantidad.Text)) mensaje += "- Es necesario la cantidad de repuestos a ingresar.\n";
                if (string.IsNullOrWhiteSpace(txtPrecio.Text)) mensaje += "- Es necesario el precio del repuesto.";
                MessageBox.Show(mensaje, "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Repuesto agregarRepuesto = new Repuesto()
                {
                    ID = Convert.ToInt32(txtID.Text),
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Stock = Convert.ToInt32(txtCantidad.Text),
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    Estado = valorCmbEstado == 1
                };

                int idRepuestoIngresado = new Negocios().regrepuSQL(agregarRepuesto, out mensaje);
                if (idRepuestoIngresado == 0)
                {
                    MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (idRepuestoIngresado != 0)
                    {
                        // Verificar si los elementos seleccionados no son nulos
                        if (selectedItemCmbEstado != null)
                        {
                            tablaRepuesto.Rows.Add(new object[] { "", idRepuestoIngresado, txtCodigo.Text, txtNombre.Text, txtCantidad.Text, txtPrecio.Text, valorCmbEstado, textoCmbEstado });
                            MessageBox.Show("El repuesto fue agregado correctamente.", "Agregar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Repuesto");
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

            int cantidad;
            decimal precio;
            if (!int.TryParse(txtCantidad.Text, out cantidad));
            if (!decimal.TryParse(txtPrecio.Text, out precio)) ;

            Repuesto repuestoModificado = new Repuesto()
            {
                ID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Stock = cantidad,
                Precio = precio,
                Estado = valorCmbEstado == 1
            };
            bool modificar = new Negocios().edirepuSQL(repuestoModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El repuesto fue modificado correctamente.", "Modificar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txtIndice.Text);
                tablaRepuesto.Rows[indice].Cells["ID"].Value = repuestoModificado.ID;
                tablaRepuesto.Rows[indice].Cells["Codigo"].Value = repuestoModificado.Codigo;
                tablaRepuesto.Rows[indice].Cells["Nombre"].Value = repuestoModificado.Nombre;
                tablaRepuesto.Rows[indice].Cells["Stock"].Value = repuestoModificado.Stock;
                tablaRepuesto.Rows[indice].Cells["Precio"].Value = repuestoModificado.Precio;
                tablaRepuesto.Rows[indice].Cells["EstadoValor"].Value = repuestoModificado.Estado ? 1 : 0;
                tablaRepuesto.Rows[indice].Cells["Estado"].Value = repuestoModificado.Estado ? "Activo" : "No Activo";
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Primero debe selecionar un repuesto en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txtID.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este repuesto?", "Eliminar repuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Repuesto repuestoEliminado = new Repuesto()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                        };
                        bool respuesta = new Negocios().elirepuSQL(repuestoEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaRepuesto.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                            MessageBox.Show("El repuesto fue eliminado correctamente.", "Eliminar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtCantidad.Clear();
            txtPrecio.Clear();
            cmbEstado.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaRepuesto.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaRepuesto.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaRepuesto.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[7].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Listado_Repuestos.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Repuestos");
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

            foreach (DataGridViewRow fila in tablaRepuesto.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscar.Text = " ";
                foreach (DataGridViewRow fila in tablaRepuesto.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void tablaRepuesto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaRepuesto.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Activo")
                {
                    DataGridViewRow row = tablaRepuesto.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaRepuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaRepuesto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = tablaRepuesto.Rows[indice].Cells["ID"].Value.ToString();
                    txtCodigo.Text = tablaRepuesto.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = tablaRepuesto.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtCantidad.Text = tablaRepuesto.Rows[indice].Cells["Stock"].Value.ToString();
                    txtPrecio.Text = tablaRepuesto.Rows[indice].Cells["Precio"].Value.ToString();

                    foreach (dynamic item in cmbEstado.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if (valor == Convert.ToInt32(tablaRepuesto.Rows[indice].Cells["EstadoValor"].Value))
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

        private void tablaRepuesto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar !=',')
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
