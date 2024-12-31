namespace CapaPresentacion
{
    partial class vtnReparacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.cmbCelular = new System.Windows.Forms.ComboBox();
            this.cmbTecnico = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregarRepuestos = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblClientes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblRepuestos = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblModeloCelular = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.tablaReparacion = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TECNICOASIGNADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELOCELULAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERVICIOASIGNADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPUESTOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadRepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cmbRepuestos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaReparacion)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServicio
            // 
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(37, 364);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(252, 28);
            this.cmbServicio.TabIndex = 205;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Wheat;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(33, 93);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(73, 20);
            this.lblCodigo.TabIndex = 202;
            this.lblCodigo.Text = "Código:";
            // 
            // cmbCelular
            // 
            this.cmbCelular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCelular.FormattingEnabled = true;
            this.cmbCelular.Location = new System.Drawing.Point(35, 304);
            this.cmbCelular.Name = "cmbCelular";
            this.cmbCelular.Size = new System.Drawing.Size(252, 28);
            this.cmbCelular.TabIndex = 204;
            // 
            // cmbTecnico
            // 
            this.cmbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTecnico.FormattingEnabled = true;
            this.cmbTecnico.Location = new System.Drawing.Point(35, 242);
            this.cmbTecnico.Name = "cmbTecnico";
            this.cmbTecnico.Size = new System.Drawing.Size(252, 28);
            this.cmbTecnico.TabIndex = 203;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Wheat;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(865, 509);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(164, 41);
            this.btnLimpiar.TabIndex = 184;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // btnAgregarRepuestos
            // 
            this.btnAgregarRepuestos.BackColor = System.Drawing.Color.Wheat;
            this.btnAgregarRepuestos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRepuestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRepuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRepuestos.Location = new System.Drawing.Point(353, 509);
            this.btnAgregarRepuestos.Name = "btnAgregarRepuestos";
            this.btnAgregarRepuestos.Size = new System.Drawing.Size(164, 41);
            this.btnAgregarRepuestos.TabIndex = 183;
            this.btnAgregarRepuestos.Text = "Agregar repuestos";
            this.btnAgregarRepuestos.UseVisualStyleBackColor = false;
            this.btnAgregarRepuestos.Click += new System.EventHandler(this.btnAgregarRepuestos_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(37, 118);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(252, 27);
            this.txtCodigo.TabIndex = 201;
            // 
            // txtIndice
            // 
            this.txtIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndice.Location = new System.Drawing.Point(200, 51);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(36, 27);
            this.txtIndice.TabIndex = 200;
            this.txtIndice.Text = "-1";
            this.txtIndice.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(253, 51);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(34, 27);
            this.txtID.TabIndex = 199;
            this.txtID.Text = "0";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.Wheat;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(606, 509);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(164, 41);
            this.btnRegistrar.TabIndex = 194;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.Location = new System.Drawing.Point(591, 48);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(498, 32);
            this.lblClientes.TabIndex = 193;
            this.lblClientes.Text = "Reparaciones del taller Don Celular";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 613);
            this.label2.TabIndex = 181;
            this.label2.Text = "Detalles Reparación";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Wheat;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(33, 522);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(73, 20);
            this.lblEstado.TabIndex = 192;
            this.lblEstado.Text = "Estado:";
            // 
            // lblRepuestos
            // 
            this.lblRepuestos.AutoSize = true;
            this.lblRepuestos.BackColor = System.Drawing.Color.Wheat;
            this.lblRepuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepuestos.Location = new System.Drawing.Point(33, 401);
            this.lblRepuestos.Name = "lblRepuestos";
            this.lblRepuestos.Size = new System.Drawing.Size(104, 20);
            this.lblRepuestos.TabIndex = 191;
            this.lblRepuestos.Text = "Repuestos:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.BackColor = System.Drawing.Color.Wheat;
            this.lblServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.Location = new System.Drawing.Point(33, 344);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(83, 20);
            this.lblServicio.TabIndex = 190;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblModeloCelular
            // 
            this.lblModeloCelular.AutoSize = true;
            this.lblModeloCelular.BackColor = System.Drawing.Color.Wheat;
            this.lblModeloCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeloCelular.Location = new System.Drawing.Point(31, 281);
            this.lblModeloCelular.Name = "lblModeloCelular";
            this.lblModeloCelular.Size = new System.Drawing.Size(141, 20);
            this.lblModeloCelular.TabIndex = 189;
            this.lblModeloCelular.Text = "Modelo Celular:";
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.BackColor = System.Drawing.Color.Wheat;
            this.lblTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico.Location = new System.Drawing.Point(33, 220);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(81, 20);
            this.lblTecnico.TabIndex = 188;
            this.lblTecnico.Text = "Técnico:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(35, 543);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(252, 28);
            this.cmbEstado.TabIndex = 187;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Wheat;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(33, 461);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(89, 20);
            this.lblCantidad.TabIndex = 207;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // tablaReparacion
            // 
            this.tablaReparacion.AllowUserToAddRows = false;
            this.tablaReparacion.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaReparacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaReparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaReparacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Cliente,
            this.TECNICOASIGNADO,
            this.MODELOCELULAR,
            this.SERVICIOASIGNADO,
            this.REPUESTOS,
            this.CantidadRepuesto,
            this.Estado,
            this.btnEliminar});
            this.tablaReparacion.Location = new System.Drawing.Point(353, 219);
            this.tablaReparacion.MultiSelect = false;
            this.tablaReparacion.Name = "tablaReparacion";
            this.tablaReparacion.ReadOnly = true;
            this.tablaReparacion.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaReparacion.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaReparacion.RowTemplate.Height = 28;
            this.tablaReparacion.Size = new System.Drawing.Size(943, 248);
            this.tablaReparacion.TabIndex = 209;
            this.tablaReparacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaReparacion_CellContentClick);
            this.tablaReparacion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tablaReparacion_CellFormatting);
            this.tablaReparacion.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tablaReparacion_CellPainting);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 120;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 125;
            // 
            // TECNICOASIGNADO
            // 
            this.TECNICOASIGNADO.HeaderText = "Técnico asignado";
            this.TECNICOASIGNADO.MinimumWidth = 6;
            this.TECNICOASIGNADO.Name = "TECNICOASIGNADO";
            this.TECNICOASIGNADO.ReadOnly = true;
            this.TECNICOASIGNADO.Width = 150;
            // 
            // MODELOCELULAR
            // 
            this.MODELOCELULAR.HeaderText = "Celular asignado";
            this.MODELOCELULAR.MinimumWidth = 6;
            this.MODELOCELULAR.Name = "MODELOCELULAR";
            this.MODELOCELULAR.ReadOnly = true;
            this.MODELOCELULAR.Width = 150;
            // 
            // SERVICIOASIGNADO
            // 
            this.SERVICIOASIGNADO.HeaderText = "Servicio";
            this.SERVICIOASIGNADO.MinimumWidth = 6;
            this.SERVICIOASIGNADO.Name = "SERVICIOASIGNADO";
            this.SERVICIOASIGNADO.ReadOnly = true;
            this.SERVICIOASIGNADO.Width = 125;
            // 
            // REPUESTOS
            // 
            this.REPUESTOS.HeaderText = "Repuestos";
            this.REPUESTOS.MinimumWidth = 6;
            this.REPUESTOS.Name = "REPUESTOS";
            this.REPUESTOS.ReadOnly = true;
            this.REPUESTOS.Width = 125;
            // 
            // CantidadRepuesto
            // 
            this.CantidadRepuesto.HeaderText = "Cantidad";
            this.CantidadRepuesto.MinimumWidth = 6;
            this.CantidadRepuesto.Name = "CantidadRepuesto";
            this.CantidadRepuesto.ReadOnly = true;
            this.CantidadRepuesto.Width = 125;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 130;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.MinimumWidth = 6;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 30;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(35, 179);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(252, 28);
            this.cmbCliente.TabIndex = 210;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.Wheat;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(33, 157);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(74, 20);
            this.lblCliente.TabIndex = 211;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(37, 482);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(250, 27);
            this.txtCantidad.TabIndex = 212;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // cmbRepuestos
            // 
            this.cmbRepuestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRepuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRepuestos.FormattingEnabled = true;
            this.cmbRepuestos.Location = new System.Drawing.Point(35, 424);
            this.cmbRepuestos.Name = "cmbRepuestos";
            this.cmbRepuestos.Size = new System.Drawing.Size(252, 28);
            this.cmbRepuestos.TabIndex = 213;
            // 
            // vtnReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1308, 613);
            this.Controls.Add(this.cmbRepuestos);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.tablaReparacion);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.cmbServicio);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.cmbCelular);
            this.Controls.Add(this.cmbTecnico);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAgregarRepuestos);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtIndice);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblRepuestos);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.lblModeloCelular);
            this.Controls.Add(this.lblTecnico);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label2);
            this.Name = "vtnReparacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reparaciónes";
            this.Load += new System.EventHandler(this.vtnReparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaReparacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cmbCelular;
        private System.Windows.Forms.ComboBox cmbTecnico;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregarRepuestos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblRepuestos;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblModeloCelular;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView tablaReparacion;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TECNICOASIGNADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELOCELULAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERVICIOASIGNADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPUESTOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cmbRepuestos;
    }
}