using CapaDatos;
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
    public partial class vtnCelular : Form
    {
        public vtnCelular()
        {
            InitializeComponent();
        }

        private void vtnCelular_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "Pendiente" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "Reparando" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaCelular.Columns)
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
            List<Cliente> mostrarCliente = new Datos().mostrarCliente();
            foreach(Cliente cliente in mostrarCliente)
            {
                cmbDuenio.Items.Add(new {Valor = cliente.ID, Texto = cliente.Nombres });
            }
            cmbDuenio.DisplayMember = "Texto";
            cmbDuenio.ValueMember = "Valor";
            if(cmbDuenio.Items.Count > 0)
            {
                cmbDuenio.SelectedIndex = 0;
            }
            else
            {
                cmbDuenio.Enabled = false;
            }

            List<Celular> mostrarCelular = new Negocios().moscelSQL();
            foreach (Celular celular in mostrarCelular)
            {
                tablaCelular.Rows.Add(new object[] { "", celular.ID, celular.Codigo, celular.Marca, celular.Modelo, celular.oCliente.ID, celular.oCliente.Nombres, celular.Estado == true ? 1 : 0, celular.Estado == true ? "Pendiente" : "Reparando" });
            }
            txtMarca.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmbDuenio = cmbDuenio.SelectedItem;
            int valorCmbDuenio = selectedItemCmbDuenio.Valor;
            string textoCmbDuenio = selectedItemCmbDuenio.Texto;

            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            // Crear una instancia de Cliente usando todos los datos necesarios
            Cliente cliente = new Cliente(valorCmbDuenio, "", "", "", "", "", "", true); 
            Celular agregarCelular = new Celular()
            {
                ID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                oCliente = cliente,
                Estado = valorCmbEstado == 1
            };

            int idCelularIngresado = new Negocios().regcelSQL(agregarCelular, out mensaje);
            if (idCelularIngresado == 0)
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idCelularIngresado != 0)
                {
                    // Verificar si los elementos seleccionados no son nulos
                    if (selectedItemCmbEstado != null)
                    {
                        tablaCelular.Rows.Add(new object[] { "", idCelularIngresado, txtCodigo.Text, txtMarca.Text, txtModelo.Text, valorCmbDuenio, textoCmbDuenio, valorCmbEstado, textoCmbEstado });
                        MessageBox.Show("El celular fue agregado correctamente.", "Agregar celular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Celular");
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
            dynamic selectedItemCmbDuenio = cmbDuenio.SelectedItem;
            int valorCmbDuenio = selectedItemCmbDuenio.Valor;
            string textoCmbDuenio = selectedItemCmbDuenio.Texto;

            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje;

            Cliente cliente = new Cliente(valorCmbDuenio, "", "", "", "", "", "", true); 

            Celular celularModificado = new Celular()
            {
                ID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                oCliente = cliente,
                Estado = valorCmbEstado == 1
            };

            bool modificar = new Negocios().edicelSQL(celularModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El celular fue modificado correctamente.", "Modificar celular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txtIndice.Text);
                tablaCelular.Rows[indice].Cells["ID"].Value = celularModificado.ID;
                tablaCelular.Rows[indice].Cells["Codigo"].Value = celularModificado.Codigo;
                tablaCelular.Rows[indice].Cells["Marca"].Value = celularModificado.Marca;
                tablaCelular.Rows[indice].Cells["Modelo"].Value = celularModificado.Modelo;
                tablaCelular.Rows[indice].Cells["IDCLIENTE"].Value = celularModificado.oCliente.ID;
                tablaCelular.Rows[indice].Cells["DuenioCelular"].Value = textoCmbDuenio;
                tablaCelular.Rows[indice].Cells["EstadoValor"].Value = celularModificado.Estado ? 1 : 0;
                tablaCelular.Rows[indice].Cells["Estado"].Value = celularModificado.Estado ? "Pendiente" : "Reparando";
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Primero debe selecionar un celular en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txtID.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este celular?", "Eliminar celular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Celular clelularEliminado = new Celular()
                        {
                            ID = Convert.ToInt32(txtID.Text),
                        };
                        bool respuesta = new Negocios().elicelSQL(clelularEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaCelular.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                            MessageBox.Show("El celular fue eliminado correctamente.", "Eliminar celular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar celular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaCelular.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaCelular.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaCelular.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[8].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Listado_Celulares.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Celulares");
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

            foreach (DataGridViewRow fila in tablaCelular.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar celular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscar.Text = " ";
                foreach (DataGridViewRow fila in tablaCelular.Rows)
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
            txtMarca.Clear();
            txtModelo.Clear();
            cmbDuenio.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
        }

        private void tablaCelular_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaCelular.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Pendiente")
                {
                    DataGridViewRow row = tablaCelular.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
            }
        }

        private void tablaCelular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaCelular.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = tablaCelular.Rows[indice].Cells["ID"].Value.ToString();
                    txtCodigo.Text = tablaCelular.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtMarca.Text = tablaCelular.Rows[indice].Cells["Marca"].Value.ToString();
                    txtModelo.Text = tablaCelular.Rows[indice].Cells["Modelo"].Value.ToString();

                    foreach (dynamic item in cmbDuenio.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if(valor == Convert.ToInt32(tablaCelular.Rows[indice].Cells["IDCLIENTE"].Value))
                        {
                            int indice_cmb = cmbDuenio.Items.IndexOf(item);
                            cmbDuenio.SelectedIndex = indice_cmb;
                            break;
                        }
                    }

                    foreach (dynamic item in cmbEstado.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if (valor == Convert.ToInt32(tablaCelular.Rows[indice].Cells["EstadoValor"].Value))
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

        private void tablaCelular_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
