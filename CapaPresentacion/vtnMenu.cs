using Entidad;
using CapaNegocios;
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
    public partial class vtnMenu : Form
    {
        private Usuario nombreUsuarioAcual;
        private static Form formularioActivo = null;
        public vtnMenu(Usuario objUsuario)
        {
            nombreUsuarioAcual = objUsuario;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void vtnMenu_Load(object sender, EventArgs e)
        {
            List<Permiso> listaVerificar = new Negocios().permeSQL(nombreUsuarioAcual.ID);

            foreach (ToolStripMenuItem iconMenu in menu2.Items)
            {
                bool encontrado = listaVerificar.Any(m => m.NombreMenu == iconMenu.Name);
                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            }
            lblUsuarioActual.Text = nombreUsuarioAcual.NombreCompleto;
            timer1.Enabled = true;
        }
        private void verPanel(Form formulario)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuItemVerUsuarios_Click(object sender, EventArgs e)
        {
            verPanel(new vtnUsuario());
        }
        private void menuItemRegistrarCiente_Click(object sender, EventArgs e)
        {
            verPanel(new vtnCliente());
        }

        private void menuItemRegistrarTecnico_Click(object sender, EventArgs e)
        {
            verPanel(new vtnTecnico());
        }

        private void menuItemRegistrarCelular_Click(object sender, EventArgs e)
        {
            verPanel(new vtnCelular());
        }

        private void menuItemRegistrarRepuesto_Click(object sender, EventArgs e)
        {
            verPanel(new vtnRepuesto());
        }

        private void menuItemRegistrarServicio_Click(object sender, EventArgs e)
        {
            verPanel(new vtnServicio());
        }

        private void menuItemRegistrarReparacion_Click(object sender, EventArgs e)
        {
            verPanel(new vtnReparacion(nombreUsuarioAcual));
        }

        private void menuItemVerDetalles_Click(object sender, EventArgs e)
        {
            verPanel(new vtnVerDetalleReparacion());
        }

        private void menuItemVerPrograma_Click(object sender, EventArgs e)
        {
            verPanel(new vtnVerPrograma());
        }

        private void menuItemVerAutores_Click(object sender, EventArgs e)
        {
            verPanel(new vtnVerAutor());
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Menú principal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
