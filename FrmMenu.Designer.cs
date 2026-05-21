namespace Proyecto_ControlAcceso_Equipo4_Sprint1
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblMenuTitulo = new System.Windows.Forms.Label();
            this.lblTotalHoy = new System.Windows.Forms.Label();
            this.lblPresentes = new System.Windows.Forms.Label();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(60)))));
            this.panelTop.Controls.Add(this.lblMenuTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.TabIndex = 3;
            // 
            // lblMenuTitulo
            // 
            this.lblMenuTitulo.ForeColor = System.Drawing.Color.White;
            this.lblMenuTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblMenuTitulo.Name = "lblMenuTitulo";
            this.lblMenuTitulo.Size = new System.Drawing.Size(200, 23);
            this.lblMenuTitulo.TabIndex = 0;
            this.lblMenuTitulo.Text = "MENU PRINCIPAL";
            // 
            // lblTotalHoy
            // 
            this.lblTotalHoy.Location = new System.Drawing.Point(30, 80);
            this.lblTotalHoy.Name = "lblTotalHoy";
            this.lblTotalHoy.Size = new System.Drawing.Size(100, 23);
            this.lblTotalHoy.TabIndex = 2;
            this.lblTotalHoy.Text = "0";
            // 
            // lblPresentes
            // 
            this.lblPresentes.Location = new System.Drawing.Point(150, 80);
            this.lblPresentes.Name = "lblPresentes";
            this.lblPresentes.Size = new System.Drawing.Size(100, 23);
            this.lblPresentes.TabIndex = 1;
            this.lblPresentes.Text = "0";
            // 
            // dgvVisitas
            // 
            this.dgvVisitas.ColumnHeadersHeight = 29;
            this.dgvVisitas.Location = new System.Drawing.Point(0, 0);
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.RowHeadersWidth = 51;
            this.dgvVisitas.Size = new System.Drawing.Size(240, 150);
            this.dgvVisitas.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(650, 400);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(0, 0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(33, 166);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(191, 166);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 22);
            this.txtDNI.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(54, 252);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FrmMenu
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblPresentes);
            this.Controls.Add(this.lblTotalHoy);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmMenu";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblMenuTitulo;
        private System.Windows.Forms.Label lblTotalHoy;
        private System.Windows.Forms.Label lblPresentes;
        private System.Windows.Forms.DataGridView dgvVisitas;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Button btnRegistrar;
    }
}