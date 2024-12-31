using CapaDatos;
using CapaNegocios;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class vtnReparacion : Form
    {
        private Usuario usuario;
        public vtnReparacion(Usuario oUsuario = null)
        {
            usuario = oUsuario;
            InitializeComponent();
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
        }

        private void vtnReparacion_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new { Valor = 1, Texto = "Reparación en proceso" });
            cmbEstado.Items.Add(new { Valor = 0, Texto = "Reparación terminada" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

            List<Cliente> listaCliente = new Datos().mostrarCliente().Where(cli => cli.Estado == true).ToList();
            foreach(Cliente clientes in listaCliente)
            {
                cmbCliente.Items.Add(new { Valor = clientes.ID, Texto = clientes.Nombres });
            }
            cmbCliente.DisplayMember = "Texto";
            cmbCliente.ValueMember = "Valor";
            if (cmbCliente.Items.Count > 0)
            {
                cmbCliente.SelectedIndex = 0;
            }
            else
            {
                cmbCliente.Enabled = false;
            }

            List<Tecnico> listaTecnico = new Datos().mostrarTecnico().Where(es => es.Estado == true).ToList();
            foreach(Tecnico tecnicos in listaTecnico)
            {
                cmbTecnico.Items.Add(new { Valor = tecnicos.ID, Texto = tecnicos.Nombres });
            }
            cmbTecnico.DisplayMember = "Texto";
            cmbTecnico.ValueMember = "Valor";
            if(cmbTecnico.Items.Count > 0)
            {
                cmbTecnico.SelectedIndex = 0;
            }
            else
            {
                cmbTecnico.Enabled = false;
            }

            List<Servicio> listaServicio = new Datos().mostrarServicio().Where(es => es.Estado == true).ToList();
            foreach (Servicio servicios in listaServicio)
            {
                cmbServicio.Items.Add(new { Valor = servicios.ID, Texto = servicios.Nombre });
            }
            cmbServicio.DisplayMember = "Texto";
            cmbServicio.ValueMember = "Valor";
            if (cmbServicio.Items.Count > 0)
            {
                cmbServicio.SelectedIndex = 0;
            }
            else
            {
                cmbServicio.Enabled = false;
            }

            List<Repuesto> listaRepuesto = new Datos().mostrarRepuesto().Where(es => es.Estado == true).ToList();
            foreach (Repuesto repuestos in listaRepuesto)
            {
                cmbRepuestos.Items.Add(new { Valor = repuestos.ID, Texto = repuestos.Nombre });
            }
            cmbRepuestos.DisplayMember = "Texto";
            cmbRepuestos.ValueMember = "Valor";
            if (cmbRepuestos.Items.Count > 0)
            {
                cmbRepuestos.SelectedIndex = 0;
            }
            else
            {
                cmbRepuestos.Enabled = false;
            }
            txtCodigo.Text = GenerarCodigo(10);

        }
        private void btnAgregarRepuestos_Click(object sender, EventArgs e)
        {
            if (cmbRepuestos.SelectedItem == null || string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, seleccione un repuesto e ingrese la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repuesto = (dynamic)cmbRepuestos.SelectedItem;
            int cantidad = int.Parse(txtCantidad.Text);

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(tablaReparacion);

            row.Cells[0].Value = txtCodigo.Text;
            row.Cells[1].Value = ((dynamic)cmbCliente.SelectedItem).Texto;
            row.Cells[2].Value = ((dynamic)cmbTecnico.SelectedItem).Texto;
            row.Cells[3].Value = ((dynamic)cmbCelular.SelectedItem).Texto;
            row.Cells[4].Value = ((dynamic)cmbServicio.SelectedItem).Texto;
            row.Cells[5].Value = repuesto.Texto;
            row.Cells[5].Tag = repuesto.Valor; 
            row.Cells[6].Value = cantidad;
            row.Cells[7].Value = cmbEstado.SelectedItem != null ? ((dynamic)cmbEstado.SelectedItem).Texto : string.Empty;

            tablaReparacion.Rows.Add(row);
            cmbRepuestos.SelectedIndex = 0;
            txtCantidad.Clear();
        }
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar()
        {
            cmbTecnico.SelectedIndex = 0;
            cmbCelular.SelectedIndex = 0;
            cmbServicio.SelectedIndex = 0;
            cmbRepuestos.SelectedIndex = 0;
            txtCantidad.Clear();
            cmbEstado.SelectedIndex = 0;
            txtCodigo.Text = GenerarCodigo(10);
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tablaReparacion.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para registrar.", "Registrar reparación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Negocios negocio = new Negocios();
            string mensaje;

            foreach (DataGridViewRow row in tablaReparacion.Rows)
            {
                Reparacion reparacion = new Reparacion
                {
                    oUsuario = new Usuario() { ID = usuario.ID },
                    Codigo = row.Cells[0].Value.ToString(),
                    oCliente = new Cliente { ID = (int)((dynamic)cmbCliente.SelectedItem).Valor },
                    oTecnico = new Tecnico { ID = (int)((dynamic)cmbTecnico.SelectedItem).Valor },
                    oCelular = new Celular { ID = (int)((dynamic)cmbCelular.SelectedItem).Valor },
                    oServicio = new Servicio { ID = (int)((dynamic)cmbServicio.SelectedItem).Valor },
                    Estado = ((dynamic)cmbEstado.SelectedItem).Valor == 1
                };

                List<Repuesto> repuestos = new List<Repuesto>();

                foreach (DataGridViewRow repuestoRow in tablaReparacion.Rows)
                {
                    if (repuestoRow.Cells[5].Value != null && repuestoRow.Cells[6].Value != null)
                    {
                        repuestos.Add(new Repuesto
                        {
                            ID = Convert.ToInt32(repuestoRow.Cells[5].Tag), 
                            Cantidad = Convert.ToInt32(repuestoRow.Cells[6].Value)
                        });
                    }
                }

                reparacion.Repuestos = repuestos;
                int idReparacion = negocio.regrepSQL(reparacion, out mensaje);
                string codigo = txtCodigo.Text;
                if (idReparacion > 0)
                {
                    int idCliente = (int)((dynamic)cmbCliente.SelectedItem).Valor;
                    bool estadoActualizadoCliente = new Negocios().edicliestSQL(idCliente, false);

                    int idTecnico = (int)((dynamic)cmbTecnico.SelectedItem).Valor;
                    bool estadoActualizadoTecnico = new Negocios().editecestSQL(idTecnico, false);

                    int idCelular = (int)((dynamic)cmbCelular.SelectedItem).Valor;
                    bool estadoActualizadoCelular = new Negocios().edicelestSQL(idCelular, false);
                    if (!estadoActualizadoCliente)
                    {
                        MessageBox.Show("Error al actualizar el estado del cliente.", "Registrar reparación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!estadoActualizadoTecnico)
                    {
                        MessageBox.Show("Error al actualizar el estado del técnico.", "Registrar reparación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("La reparación fue registrada exitosamente", "Registrar reparación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var result = MessageBox.Show("Código de reparación generado:\n" + codigo + "\n\n ¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            System.Windows.Forms.Clipboard.SetText(codigo);
                        }
                    }
                }
            }
        }

        private void tablaReparacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaReparacion.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && (string)e.Value == "Reparación terminada")
                {
                    DataGridViewRow row = tablaReparacion.Rows[e.RowIndex];
                    e.CellStyle.BackColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private void tablaReparacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tablaReparacion.Columns["btnEliminar"].Index && e.RowIndex >= 0)
            {
                int filaSeleccionada = e.RowIndex;

                tablaReparacion.Rows.RemoveAt(filaSeleccionada);
            }
        }
        private void tablaReparacion_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var p = Properties.Resources.eliminar.Width;
                var q = Properties.Resources.eliminar.Height;
                var r = e.CellBounds.Left + (e.CellBounds.Width - p) / 2;
                var s = e.CellBounds.Top + (e.CellBounds.Height - q) / 2;
                e.Graphics.DrawImage(Properties.Resources.eliminar, new Rectangle(r, s, p, q));
                e.Handled = true;
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clienteSeleccionado = (dynamic)cmbCliente.SelectedItem;
            int idCliente = clienteSeleccionado.Valor;
            List<Celular> listaCelular = new Datos().mostrarCelular();
            List<Celular> celularesCliente = listaCelular.Where(c => c.oCliente.ID == idCliente && c.Estado).ToList();
            cmbCelular.Items.Clear();
            foreach (var celulares in celularesCliente)
            {
                cmbCelular.Items.Add(new { Valor = celulares.ID, Texto = celulares.Modelo });
            }
            cmbCelular.DisplayMember = "Texto";
            cmbCelular.ValueMember = "Valor";
            if (cmbCelular.Items.Count > 0)
            {
                cmbCelular.SelectedIndex = 0;
                cmbCelular.Enabled = true;
            }
            else
            {
                cmbCelular.Enabled = false;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Debe ingresar números y no letras.", "Campo Cédula", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
