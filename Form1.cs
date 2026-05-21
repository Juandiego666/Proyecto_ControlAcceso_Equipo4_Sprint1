using System;
using System.Windows.Forms;

namespace Proyecto_ControlAcceso_Equipo4_Sprint1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos la clase de datos que acabamos de crear
            CD_Usuario objetoData = new CD_Usuario();

            string user = txtUsuario.Text;
            string pass = txtPassword.Text;

            // 2. Validamos que los campos no estén vacíos antes de preguntar a la DB
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, rellene todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Llamamos al método de validación real
            bool loginExitoso = objetoData.ValidarUsuario(user, pass);

            if (loginExitoso)
            {
                // Entra al sistema
                MessageBox.Show("Acceso concedido", "Sistema Metro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmMenu menu = new FrmMenu();
                menu.Show();
                this.Hide(); // Ocultamos el login
            }
            else
            {
                // Bloquea el paso
                MessageBox.Show("Usuario o Contraseña incorrectos", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }
    }
}