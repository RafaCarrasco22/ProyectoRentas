namespace ProyectoVideo
{
    partial class VerRentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerRentas));
            this.label1 = new System.Windows.Forms.Label();
            this.dataviwe = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnEn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataviwe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 38);
            this.label1.TabIndex = 15;
            this.label1.Text = "VER RENTAS";
            // 
            // dataviwe
            // 
            this.dataviwe.AllowUserToAddRows = false;
            this.dataviwe.AllowUserToDeleteRows = false;
            this.dataviwe.AllowUserToResizeColumns = false;
            this.dataviwe.AllowUserToResizeRows = false;
            this.dataviwe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataviwe.BackgroundColor = System.Drawing.Color.DarkSalmon;
            this.dataviwe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataviwe.Location = new System.Drawing.Point(-2, 92);
            this.dataviwe.Name = "dataviwe";
            this.dataviwe.Size = new System.Drawing.Size(857, 326);
            this.dataviwe.TabIndex = 16;
            this.dataviwe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataviwe_CellContentClick);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(768, 424);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Aceptar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnEn
            // 
            this.btnEn.Location = new System.Drawing.Point(12, 424);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(116, 23);
            this.btnEn.TabIndex = 18;
            this.btnEn.Text = "Entregas del día";
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // VerRentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(855, 459);
            this.Controls.Add(this.btnEn);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dataviwe);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerRentas";
            this.Text = "VerRentas";
            this.Load += new System.EventHandler(this.VerRentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataviwe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataviwe;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnEn;
    }
}