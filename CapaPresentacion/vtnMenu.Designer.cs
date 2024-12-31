namespace CapaPresentacion
{
    partial class vtnMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vtnMenu));
            this.menu2 = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegistrarCiente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTecnico = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegistrarTecnico = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegistrarRepuesto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCelular = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegistrarCelular = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegistrarServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReparacion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegistrarReparacion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVerDetalles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVerPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemVerAutores = new System.Windows.Forms.ToolStripMenuItem();
            this.menu1 = new System.Windows.Forms.MenuStrip();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.menu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu2
            // 
            this.menu2.AutoSize = false;
            this.menu2.BackColor = System.Drawing.Color.Wheat;
            this.menu2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuCliente,
            this.menuTecnico,
            this.menuRepuesto,
            this.menuCelular,
            this.menuServicio,
            this.menuReparacion,
            this.menuAcercaDe});
            this.menu2.Location = new System.Drawing.Point(0, 87);
            this.menu2.Name = "menu2";
            this.menu2.Size = new System.Drawing.Size(1317, 73);
            this.menu2.TabIndex = 0;
            this.menu2.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerUsuarios});
            this.menuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuUsuarios.Image = global::CapaPresentacion.Properties.Resources.usuarios;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(89, 69);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerUsuarios
            // 
            this.menuItemVerUsuarios.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerUsuarios.Name = "menuItemVerUsuarios";
            this.menuItemVerUsuarios.Size = new System.Drawing.Size(187, 28);
            this.menuItemVerUsuarios.Text = "Ver usuarios";
            this.menuItemVerUsuarios.Click += new System.EventHandler(this.menuItemVerUsuarios_Click);
            // 
            // menuCliente
            // 
            this.menuCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRegistrarCiente});
            this.menuCliente.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCliente.Image = global::CapaPresentacion.Properties.Resources.clientes;
            this.menuCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(77, 69);
            this.menuCliente.Text = "Cliente";
            this.menuCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRegistrarCiente
            // 
            this.menuItemRegistrarCiente.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRegistrarCiente.Name = "menuItemRegistrarCiente";
            this.menuItemRegistrarCiente.Size = new System.Drawing.Size(216, 28);
            this.menuItemRegistrarCiente.Text = "Registrar cliente";
            this.menuItemRegistrarCiente.Click += new System.EventHandler(this.menuItemRegistrarCiente_Click);
            // 
            // menuTecnico
            // 
            this.menuTecnico.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRegistrarTecnico});
            this.menuTecnico.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTecnico.Image = global::CapaPresentacion.Properties.Resources.tecnico;
            this.menuTecnico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuTecnico.Name = "menuTecnico";
            this.menuTecnico.Size = new System.Drawing.Size(80, 69);
            this.menuTecnico.Text = "Técnico";
            this.menuTecnico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuTecnico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRegistrarTecnico
            // 
            this.menuItemRegistrarTecnico.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRegistrarTecnico.Name = "menuItemRegistrarTecnico";
            this.menuItemRegistrarTecnico.Size = new System.Drawing.Size(221, 28);
            this.menuItemRegistrarTecnico.Text = "Registrar técnico";
            this.menuItemRegistrarTecnico.Click += new System.EventHandler(this.menuItemRegistrarTecnico_Click);
            // 
            // menuRepuesto
            // 
            this.menuRepuesto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRegistrarRepuesto});
            this.menuRepuesto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuRepuesto.Image = global::CapaPresentacion.Properties.Resources.repuesto;
            this.menuRepuesto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuRepuesto.Name = "menuRepuesto";
            this.menuRepuesto.Size = new System.Drawing.Size(95, 69);
            this.menuRepuesto.Text = "Repuesto";
            this.menuRepuesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuRepuesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRegistrarRepuesto
            // 
            this.menuItemRegistrarRepuesto.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRegistrarRepuesto.Name = "menuItemRegistrarRepuesto";
            this.menuItemRegistrarRepuesto.Size = new System.Drawing.Size(233, 28);
            this.menuItemRegistrarRepuesto.Text = "Registrar repuesto";
            this.menuItemRegistrarRepuesto.Click += new System.EventHandler(this.menuItemRegistrarRepuesto_Click);
            // 
            // menuCelular
            // 
            this.menuCelular.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRegistrarCelular});
            this.menuCelular.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCelular.Image = global::CapaPresentacion.Properties.Resources.celular;
            this.menuCelular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCelular.Name = "menuCelular";
            this.menuCelular.Size = new System.Drawing.Size(77, 69);
            this.menuCelular.Text = "Celular";
            this.menuCelular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuCelular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRegistrarCelular
            // 
            this.menuItemRegistrarCelular.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRegistrarCelular.Name = "menuItemRegistrarCelular";
            this.menuItemRegistrarCelular.Size = new System.Drawing.Size(216, 28);
            this.menuItemRegistrarCelular.Text = "Registrar celular";
            this.menuItemRegistrarCelular.Click += new System.EventHandler(this.menuItemRegistrarCelular_Click);
            // 
            // menuServicio
            // 
            this.menuServicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRegistrarServicio});
            this.menuServicio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuServicio.Image = global::CapaPresentacion.Properties.Resources.servicio;
            this.menuServicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuServicio.Name = "menuServicio";
            this.menuServicio.Size = new System.Drawing.Size(82, 69);
            this.menuServicio.Text = "Servicio";
            this.menuServicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuServicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRegistrarServicio
            // 
            this.menuItemRegistrarServicio.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRegistrarServicio.Name = "menuItemRegistrarServicio";
            this.menuItemRegistrarServicio.Size = new System.Drawing.Size(222, 28);
            this.menuItemRegistrarServicio.Text = "Registrar servicio";
            this.menuItemRegistrarServicio.Click += new System.EventHandler(this.menuItemRegistrarServicio_Click);
            // 
            // menuReparacion
            // 
            this.menuReparacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRegistrarReparacion,
            this.toolStripSeparator1,
            this.menuItemVerDetalles});
            this.menuReparacion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReparacion.Image = global::CapaPresentacion.Properties.Resources.reparacionTelefono;
            this.menuReparacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReparacion.Name = "menuReparacion";
            this.menuReparacion.Size = new System.Drawing.Size(109, 69);
            this.menuReparacion.Text = "Reparación";
            this.menuReparacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuReparacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemRegistrarReparacion
            // 
            this.menuItemRegistrarReparacion.BackColor = System.Drawing.Color.Wheat;
            this.menuItemRegistrarReparacion.Name = "menuItemRegistrarReparacion";
            this.menuItemRegistrarReparacion.Size = new System.Drawing.Size(247, 28);
            this.menuItemRegistrarReparacion.Text = "Registrar reparación";
            this.menuItemRegistrarReparacion.Click += new System.EventHandler(this.menuItemRegistrarReparacion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Wheat;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // menuItemVerDetalles
            // 
            this.menuItemVerDetalles.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerDetalles.Name = "menuItemVerDetalles";
            this.menuItemVerDetalles.Size = new System.Drawing.Size(247, 28);
            this.menuItemVerDetalles.Text = "Ver detalles";
            this.menuItemVerDetalles.Click += new System.EventHandler(this.menuItemVerDetalles_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemVerPrograma,
            this.toolStripSeparator2,
            this.menuItemVerAutores});
            this.menuAcercaDe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAcercaDe.Image = global::CapaPresentacion.Properties.Resources.informacion;
            this.menuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(101, 69);
            this.menuAcercaDe.Text = "Acerca De";
            this.menuAcercaDe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemVerPrograma
            // 
            this.menuItemVerPrograma.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerPrograma.Name = "menuItemVerPrograma";
            this.menuItemVerPrograma.Size = new System.Drawing.Size(199, 28);
            this.menuItemVerPrograma.Text = "Ver programa";
            this.menuItemVerPrograma.Click += new System.EventHandler(this.menuItemVerPrograma_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // menuItemVerAutores
            // 
            this.menuItemVerAutores.BackColor = System.Drawing.Color.Wheat;
            this.menuItemVerAutores.Name = "menuItemVerAutores";
            this.menuItemVerAutores.Size = new System.Drawing.Size(199, 28);
            this.menuItemVerAutores.Text = "Ver autores";
            this.menuItemVerAutores.Click += new System.EventHandler(this.menuItemVerAutores_Click);
            // 
            // menu1
            // 
            this.menu1.AutoSize = false;
            this.menu1.BackColor = System.Drawing.Color.White;
            this.menu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(1317, 87);
            this.menu1.TabIndex = 1;
            this.menu1.Text = "menuStrip2";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(13, 53);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(60, 20);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.White;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(1184, 34);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(46, 20);
            this.lblHora.TabIndex = 20;
            this.lblHora.Text = "hora";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 160);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1317, 622);
            this.panel.TabIndex = 22;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(512, 29);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(379, 32);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Reparaciones Don Celular ";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Wheat;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Wheat;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Image = global::CapaPresentacion.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(1236, 87);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 73);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.BackColor = System.Drawing.Color.White;
            this.lblUsuarioActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioActual.Location = new System.Drawing.Point(13, 16);
            this.lblUsuarioActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(94, 20);
            this.lblUsuarioActual.TabIndex = 24;
            this.lblUsuarioActual.Text = "lblUsuario";
            // 
            // vtnMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1317, 782);
            this.Controls.Add(this.lblUsuarioActual);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.menu2);
            this.Controls.Add(this.menu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu2;
            this.MaximizeBox = false;
            this.Name = "vtnMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.Load += new System.EventHandler(this.vtnMenu_Load);
            this.menu2.ResumeLayout(false);
            this.menu2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu2;
        private System.Windows.Forms.MenuStrip menu1;
        private System.Windows.Forms.ToolStripMenuItem menuCliente;
        private System.Windows.Forms.ToolStripMenuItem menuTecnico;
        private System.Windows.Forms.ToolStripMenuItem menuCelular;
        private System.Windows.Forms.ToolStripMenuItem menuRepuesto;
        private System.Windows.Forms.ToolStripMenuItem menuServicio;
        private System.Windows.Forms.ToolStripMenuItem menuReparacion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem menuAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegistrarCiente;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegistrarTecnico;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegistrarCelular;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegistrarRepuesto;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegistrarServicio;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegistrarReparacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerDetalles;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerPrograma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerAutores;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuItemVerUsuarios;
        private System.Windows.Forms.Label lblUsuarioActual;
    }
}

