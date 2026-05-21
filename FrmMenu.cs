using System;
using System.Data;
using System.Windows.Forms;
using Proyecto_ControlAcceso_Equipo4_Sprint1.Datos; // Esto conecta con CD_Visitas

namespace Proyecto_ControlAcceso_Equipo4_Sprint1
{
    public partial class FrmMenu : Form
    {
        // Instancia de la capa de datos
        private CD_Visitas objetoData = new CD_Visitas();

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            ActualizarDashboard();
        }

        // Método para refrescar los contadores
        private void ActualizarDashboard()
        {
            DataTable dt = objetoData.ObtenerEstadisticas();
            if (dt.Rows.Count > 0)
            {
                lblTotalHoy.Text = dt.Rows[0]["TotalHoy"].ToString();
                lblPresentes.Text = dt.Rows[0]["Presentes"].ToString();
            }
        }

        // --- ESTE ES EL MÉTODO QUE HARÁ EL TRABAJO ---
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validamos que los cuadros de texto no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, llene el DNI y el Nombre", "Campos obligatorios");
                return;
            }

            // Llamamos a la base de datos
            bool exito = objetoData.RegistrarVisita(txtDNI.Text, txtNombre.Text);

            if (exito)
            {
                MessageBox.Show("¡Visita registrada correctamente!", "Éxito");
                txtDNI.Clear();
                txtNombre.Clear();
                ActualizarDashboard(); // Refresca los números automáticamente
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exportando reporte...");
        }
    }
}