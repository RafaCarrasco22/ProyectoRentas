namespace ProyectoVideo
{
    partial class FormEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmpleado));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPelículaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPelículaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarPelículaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarPelículaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabBusqueda = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft MHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.agregarPelículaToolStripMenuItem,
            this.rentarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 34);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.clienteToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(84, 30);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // agregarPelículaToolStripMenuItem
            // 
            this.agregarPelículaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarPelículaToolStripMenuItem1,
            this.modificarPelículaToolStripMenuItem,
            this.eliminarPelículaToolStripMenuItem});
            this.agregarPelículaToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.agregarPelículaToolStripMenuItem.Name = "agregarPelículaToolStripMenuItem";
            this.agregarPelículaToolStripMenuItem.Size = new System.Drawing.Size(90, 30);
            this.agregarPelículaToolStripMenuItem.Text = "Película";
            // 
            // agregarPelículaToolStripMenuItem1
            // 
            this.agregarPelículaToolStripMenuItem1.Name = "agregarPelículaToolStripMenuItem1";
            this.agregarPelículaToolStripMenuItem1.Size = new System.Drawing.Size(238, 30);
            this.agregarPelículaToolStripMenuItem1.Text = "Agregar Película";
            this.agregarPelículaToolStripMenuItem1.Click += new System.EventHandler(this.agregarPelículaToolStripMenuItem1_Click);
            // 
            // modificarPelículaToolStripMenuItem
            // 
            this.modificarPelículaToolStripMenuItem.Name = "modificarPelículaToolStripMenuItem";
            this.modificarPelículaToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.modificarPelículaToolStripMenuItem.Text = "Modificar Película";
            this.modificarPelículaToolStripMenuItem.Click += new System.EventHandler(this.modificarPelículaToolStripMenuItem_Click);
            // 
            // eliminarPelículaToolStripMenuItem
            // 
            this.eliminarPelículaToolStripMenuItem.Name = "eliminarPelículaToolStripMenuItem";
            this.eliminarPelículaToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.eliminarPelículaToolStripMenuItem.Text = "Eliminar Película";
            this.eliminarPelículaToolStripMenuItem.Click += new System.EventHandler(this.eliminarPelículaToolStripMenuItem_Click);
            // 
            // rentarToolStripMenuItem
            // 
            this.rentarToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.rentarToolStripMenuItem.Name = "rentarToolStripMenuItem";
            this.rentarToolStripMenuItem.Size = new System.Drawing.Size(81, 30);
            this.rentarToolStripMenuItem.Text = "Rentar";
            this.rentarToolStripMenuItem.Click += new System.EventHandler(this.rentarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.ForeColor = System.Drawing.Color.Orange;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(61, 30);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tabBusqueda
            // 
            this.tabBusqueda.AllowUserToAddRows = false;
            this.tabBusqueda.AllowUserToDeleteRows = false;
            this.tabBusqueda.AllowUserToResizeColumns = false;
            this.tabBusqueda.AllowUserToResizeRows = false;
            this.tabBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabBusqueda.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.tabBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabBusqueda.Location = new System.Drawing.Point(0, 87);
            this.tabBusqueda.Name = "tabBusqueda";
            this.tabBusqueda.ReadOnly = true;
            this.tabBusqueda.Size = new System.Drawing.Size(798, 347);
            this.tabBusqueda.TabIndex = 1;
            this.tabBusqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabBusqueda_CellContentClick);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(448, 43);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(32, 39);
            this.btnFind.TabIndex = 2;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar película";
            // 
            // cmbBusca
            // 
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.Items.AddRange(new object[] {
            "Nombre",
            "Género",
            "Año Lanzamiento"});
            this.cmbBusca.Location = new System.Drawing.Point(146, 53);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 4;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(273, 54);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(169, 20);
            this.txtBusqueda.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(698, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "Ver Rentas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(486, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(38, 34);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(798, 498);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tabBusqueda);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(814, 537);
            this.MinimumSize = new System.Drawing.Size(814, 537);
            this.Name = "FormEmpleado";
            this.Text = "FormEmpleado";
            this.Load += new System.EventHandler(this.FormEmpleado_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView tabBusqueda;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem agregarPelículaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarPelículaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarPelículaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarPelículaToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
    }
}