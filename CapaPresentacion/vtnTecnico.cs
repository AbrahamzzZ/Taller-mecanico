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
    public partial class vtnTecnico : Form
    {
        public vtnTecnico()
        {
            InitializeComponent();
        }

        private void vtnTecnico_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "Desocupado" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "Ocupado" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablaTecnico.Columns)
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
            List<Tecnico> mostrarTecnico = new Negocios().mostecSQL();
            foreach (Tecnico tecnico in mostrarTecnico)
            {
                tablaTecnico.Rows.Add(new object[] { "", tecnico.ID, tecnico.Codigo, tecnico.Nombres, tecnico.Apellidos, tecnico.Cedula, tecnico.Telefono, tecnico.CorreoElectronico, tecnico.Especializacion, tecnico.Anios_Experiencia, tecnico.Estado == true ? 1 : 0, tecnico.Estado == true ? "Desocupado" : "Ocupado" });
            }
            txtNombres.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dynamic selectedItemCmbEstado = cmbEstado.SelectedItem;
            int valorCmbEstado = selectedItemCmbEstado.Valor;
            string textoCmbEstado = selectedItemCmbEstado.Texto;
            string mensaje = string.Empty;

            Tecnico agregarTecnico = new Tecnico(
                0,  
                txtCodigo.Text,
                txtNombres.Text,
                txtApellidos.Text,
                txtCedula.Text,
                txtTelefono.Text,
                txtCorreoElectronico.Text,
                txtEspecializacion.Text,
                Convert.ToInt32(txtAniosExperiencia.Text),
                valorCmbEstado == 1
            );

            int idTecnicoIngresado = new Negocios().regtecSQL(agregarTecnico, out mensaje);
            if (idTecnicoIngresado == 0)
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idTecnicoIngresado != 0)
                {
                    if (selectedItemCmbEstado != null)
                    {
                        tablaTecnico.Rows.Add(new object[] { "", idTecnicoIngresado, txtCodigo.Text, txtNombres.Text, txtApellidos.Text, txtCedula.Text, txtTelefono.Text, txtCorreoElectronico.Text, txtEspecializacion.Text, txtAniosExperiencia.Text, valorCmbEstado, textoCmbEstado });
                        MessageBox.Show("El técnico fue agregado correctamente.", "Agregar técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un valor en ambos comboboxes.", "Tabla Técnico");
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

            Tecnico tecnicoModificado = new Tecnico(
                Convert.ToInt32(txtID.Text),
                txtCodigo.Text,
                txtNombres.Text,
                txtApellidos.Text,
                txtCedula.Text,
                txtTelefono.Text,
                txtCorreoElectronico.Text,
                txtEspecializacion.Text,
                Convert.ToInt32(txtAniosExperiencia.Text),
                valorCmbEstado == 1
            );

            bool modificar = new Negocios().editecSQL(tecnicoModificado, out mensaje);
            if (modificar)
            {
                MessageBox.Show("El técnico fue modificado correctamente.", "Modificar técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indice = Convert.ToInt32(txtIndice.Text);
                tablaTecnico.Rows[indice].Cells["ID"].Value = tecnicoModificado.ID;
                tablaTecnico.Rows[indice].Cells["Codigo"].Value = tecnicoModificado.Codigo;
                tablaTecnico.Rows[indice].Cells["Nombre"].Value = tecnicoModificado.Nombres;
                tablaTecnico.Rows[indice].Cells["Apellidos"].Value = tecnicoModificado.Apellidos;
                tablaTecnico.Rows[indice].Cells["Cedula"].Value = tecnicoModificado.Cedula;
                tablaTecnico.Rows[indice].Cells["Telefono"].Value = tecnicoModificado.Telefono;
                tablaTecnico.Rows[indice].Cells["CorreoElectronico"].Value = tecnicoModificado.CorreoElectronico;
                tablaTecnico.Rows[indice].Cells["Especializacion"].Value = tecnicoModificado.Especializacion;
                tablaTecnico.Rows[indice].Cells["AniosExperiencia"].Value = tecnicoModificado.Anios_Experiencia;
                tablaTecnico.Rows[indice].Cells["EstadoValor"].Value = tecnicoModificado.Estado ? 1 : 0;
                tablaTecnico.Rows[indice].Cells["Estado"].Value = tecnicoModificado.Estado ? "Desocupado" : "Ocupado";
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || string.IsNullOrWhiteSpace(txtEspecializacion.Text) || string.IsNullOrWhiteSpace(txtAniosExperiencia.Text))
            {
                MessageBox.Show("Primero debe selecionar un técnico en la tabla para poder eliminarlo.", "Faltan campos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txtID.Text) != 0)
                {
                    if (MessageBox.Show("Desea eliminar este técnico?", "Eliminar técnico", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string mensaje = string.Empty;

                        Tecnico tecnicoEliminado = new Tecnico(
                            Convert.ToInt32(txtID.Text),
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            0,
                            false
                        );

                        bool respuesta = new Negocios().elitecSQL(tecnicoEliminado, out mensaje);
                        if (respuesta)
                        {
                            tablaTecnico.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                            MessageBox.Show("El técnico fue eliminado correctamente.", "Eliminar técnico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Eliminar técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (tablaTecnico.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos en la tabla para exportar.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablaTecnico.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow row in tablaTecnico.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[11].Value.ToString()
                        });
                    }
                }
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = string.Format("Listado_Técnicos.xlsx");
                guardar.Filter = "Excel Files | *.xlsx";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Técnicos");
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

            foreach (DataGridViewRow fila in tablaTecnico.Rows)
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
                MessageBox.Show("No se encontró información de acuerdo a la opción seleccionada.", "Buscar técnico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscar.Text = " ";
                foreach (DataGridViewRow fila in tablaTecnico.Rows)
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
            txtEspecializacion.Clear();
            txtAniosExperiencia.Clear();
            cmbEstado.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
        }

        private void tablaTecnico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaTecnico.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Desocupado")
                {
                    DataGridViewRow row = tablaTecnico.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaTecnico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaTecnico.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = tablaTecnico.Rows[indice].Cells["ID"].Value.ToString();
                    txtCodigo.Text = tablaTecnico.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombres.Text = tablaTecnico.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtApellidos.Text = tablaTecnico.Rows[indice].Cells["Apellidos"].Value.ToString();
                    txtCedula.Text = tablaTecnico.Rows[indice].Cells["Cedula"].Value.ToString();
                    txtTelefono.Text = tablaTecnico.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtCorreoElectronico.Text = tablaTecnico.Rows[indice].Cells["CorreoElectronico"].Value.ToString();
                    txtEspecializacion.Text = tablaTecnico.Rows[indice].Cells["Especializacion"].Value.ToString();
                    txtAniosExperiencia.Text = tablaTecnico.Rows[indice].Cells["AniosExperiencia"].Value.ToString();

                    foreach (dynamic item in cmbEstado.Items)
                    {
                        int valor = item.Valor;
                        string texto = item.Texto;
                        if (valor == Convert.ToInt32(tablaTecnico.Rows[indice].Cells["EstadoValor"].Value))
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

        private void tablaTecnico_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtEspecializacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Debe ingresar letras y no números.", "Campo Especialización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtAniosExperiencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Años de experiencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
