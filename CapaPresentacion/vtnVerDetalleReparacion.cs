using DocumentFormat.OpenXml.Spreadsheet;
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
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Xml.Linq;

namespace CapaPresentacion
{
    public partial class vtnVerDetalleReparacion : Form
    {
        public vtnVerDetalleReparacion()
        {
            InitializeComponent();
        }
        private void vtnVerDetalleReparacion_Load(object sender, EventArgs e)
        {
            txtCodigo.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Reparacion oReparacion = new Negocios().obtrepSQL(txtCodigo.Text);
            if (oReparacion != null)
            {
                txtFechaReparacion.Text = oReparacion.Fecha_Registro;
                txtUsuarioActual.Text = oReparacion.oUsuario.NombreCompleto;

                txtCedulaTecnico.Text = oReparacion.oTecnico.Cedula;
                txtIDTecnico.Text = oReparacion.oTecnico.ID.ToString();
                txtNombreTecnico.Text = oReparacion.oTecnico.Nombres;

                txtMarca.Text = oReparacion.oCelular.Marca;
                txtIDCelular.Text = oReparacion.oCelular.ID.ToString();
                txtModelo.Text = oReparacion.oCelular.Modelo;

                txtCedulaCliente.Text = oReparacion.oCliente.Cedula;
                txtIDCliente.Text = oReparacion.oCliente.ID.ToString();
                txtNombreCliente.Text = oReparacion.oCliente.Nombres;

                txtIDServicio.Text = oReparacion.oServicio.ID.ToString();
                txtNombreServicio.Text = oReparacion.oServicio.Nombre;
                txtPrecio.Text = oReparacion.oServicio.Precio.ToString();

                decimal totalRepuestos = 0;
                decimal totalServicio = Convert.ToDecimal(txtPrecio.Text);

                tablaDetallesReparacion.Rows.Clear();
                foreach (Detalle_Reparacion dr in oReparacion.oDetalle_Reparacion)
                {
                    foreach (Repuesto rep in dr.Repuestos)
                    {
                        totalRepuestos += rep.Cantidad * rep.Precio;

                        tablaDetallesReparacion.Rows.Add(new object[]
                        { rep.Nombre, rep.Cantidad, rep.Precio});
                    }
                }
                decimal precioFinal = totalRepuestos + totalServicio;
                txtPrecioFinal.Text = precioFinal.ToString("C2"); 
            }
            else
            {
                MessageBox.Show("El código de la reparación ingresado no existe.", "Detalles de la reparación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtFechaReparacion.Clear();
            txtUsuarioActual.Clear();
            txtCedulaTecnico.Clear();
            txtIDTecnico.Clear();
            txtNombreTecnico.Clear();
            txtMarca.Clear();
            txtIDCelular.Clear();
            txtModelo.Clear();
            txtCedulaCliente.Clear();
            txtIDCliente.Clear();
            txtNombreCliente.Clear();
            txtNombreServicio.Clear();
            txtIDServicio.Clear();
            txtPrecio.Clear();
            tablaDetallesReparacion.Rows.Clear();
            txtPrecioFinal.Clear();
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF file|*.pdf";
            saveFileDialog.Title = "Guardar Detalles de Reparación como PDF";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    var imageResource = Properties.Resources.DonCelular; 
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imageResource, System.Drawing.Imaging.ImageFormat.Png);

                 
                    logo.ScaleToFit(200, 100); 
                    logo.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(logo);

                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Detalle de Reparación", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Código: " + txtCodigo.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Fecha de Reparación: " + txtFechaReparacion.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Usuario Actual: " + txtUsuarioActual.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Cédula Técnico: " + txtCedulaTecnico.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Nombre Técnico: " + txtNombreTecnico.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Marca Celular: " + txtMarca.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Modelo Celular: " + txtModelo.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Cédula Cliente: " + txtCedulaCliente.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Nombre Cliente: " + txtNombreCliente.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Nombre Servicio: " + txtNombreServicio.Text));
                    pdfDoc.Add(new iTextSharp.text.Paragraph("Precio Servicio: " + txtPrecio.Text));

                    pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                    PdfPTable table = new PdfPTable(tablaDetallesReparacion.ColumnCount);

                    foreach (DataGridViewColumn column in tablaDetallesReparacion.Columns)
                    {
                        table.AddCell(new Phrase(column.HeaderText));
                    }

                    foreach (DataGridViewRow row in tablaDetallesReparacion.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Phrase(cell.Value == null ? "" : cell.Value.ToString()));
                        }
                    }

                    pdfDoc.Add(new iTextSharp.text.Paragraph("Precio Final: " + txtPrecioFinal.Text));
                    pdfDoc.Add(table);

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF generado exitosamente.", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
        }
    }
}
