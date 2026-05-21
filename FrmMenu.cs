using System;
using System.Data;
using System.Drawing;
using System.IO; // Requerido para la escritura del archivo de descarga
using System.Text; // Requerido para el encoding del reporte
using System.Windows.Forms;
using Proyecto_ControlAcceso_Equipo4_Sprint1.Negocio;

namespace Proyecto_ControlAcceso_Equipo4_Sprint1
{
    public partial class FrmMenu : Form
    {
        private CN_Visitas objetoData = new CN_Visitas();

        // Componentes de diseño premium
        private Label lblDniFijo = new Label();
        private Label lblNombreFijo = new Label();
        private Label lblTotalTexto = new Label();
        private Label lblPresentesTexto = new Label();
        private Panel panelSeparador = new Panel();

        // CONTENEDOR DE TABLEROS (Pestañas modernas)
        private TabControl tabContenedor = new TabControl();
        private TabPage tabDentroEstacion = new TabPage();
        private TabPage tabHistorialCompleto = new TabPage();

        // LAS DOS TABLAS SEPARADAS
        private DataGridView dgvDentro = new DataGridView();
        private DataGridView dgvHistorial = new DataGridView();

        // Botón físico para salida
        private Button btnRegistrarSalidaDirecta = new Button();

        public FrmMenu()
        {
            InitializeComponent();
            AplicarDiseñoPremiumUX();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            ActualizarDashboard();
            CargarTableros();
        }

        private void AplicarDiseñoPremiumUX()
        {
            // 1. CONFIGURACIÓN DEL FORMULARIO PRINCIPAL
            this.Size = new Size(950, 560);
            this.Text = "Sistema de Control de Acceso - Línea del Metro";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // 2. PANEL SUPERIOR (MENU PRINCIPAL)
            panelTop.BackColor = Color.FromArgb(0, 130, 60);
            panelTop.Height = 65;
            lblMenuTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblMenuTitulo.Location = new Point(25, 20);
            lblMenuTitulo.Size = new Size(300, 30);

            // Separador visual izquierdo
            panelSeparador.BackColor = Color.FromArgb(215, 220, 225);
            panelSeparador.Location = new Point(295, 85);
            panelSeparador.Size = new Size(2, 390);
            this.Controls.Add(panelSeparador);

            // 3. SECCIÓN DASHBOARD (Tarjetas de indicadores)
            lblTotalTexto.Text = "TOTAL INGRESOS HOY";
            lblTotalTexto.Location = new Point(40, 85);
            lblTotalTexto.Size = new Size(130, 15);
            lblTotalTexto.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblTotalTexto.ForeColor = Color.FromArgb(120, 130, 140);
            this.Controls.Add(lblTotalTexto);

            lblTotalHoy.Location = new Point(40, 102);
            lblTotalHoy.Size = new Size(80, 30);
            lblTotalHoy.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTotalHoy.ForeColor = Color.FromArgb(0, 130, 60);

            lblPresentesTexto.Text = "DENTRO DE ESTACIÓN";
            lblPresentesTexto.Location = new Point(165, 85);
            lblPresentesTexto.Size = new Size(130, 15);
            lblPresentesTexto.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblPresentesTexto.ForeColor = Color.FromArgb(120, 130, 140);
            this.Controls.Add(lblPresentesTexto);

            lblPresentes.Location = new Point(165, 102);
            lblPresentes.Size = new Size(80, 30);
            lblPresentes.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblPresentes.ForeColor = Color.FromArgb(230, 90, 40);

            // 4. TEXTBOXES Y ETIQUETAS
            lblNombreFijo.Text = "Nombre Completo (Solo Ingresos)";
            lblNombreFijo.Location = new Point(40, 160);
            lblNombreFijo.Size = new Size(240, 18);
            lblNombreFijo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblNombreFijo.ForeColor = Color.FromArgb(60, 70, 80);
            this.Controls.Add(lblNombreFijo);

            txtNombre.Location = new Point(40, 183);
            txtNombre.Size = new Size(235, 25);
            txtNombre.Font = new Font("Segoe UI", 10);

            lblDniFijo.Text = "Número de DNI (Ingreso o Salida)";
            lblDniFijo.Location = new Point(40, 225);
            lblDniFijo.Size = new Size(240, 18);
            lblDniFijo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblDniFijo.ForeColor = Color.FromArgb(60, 70, 80);
            this.Controls.Add(lblDniFijo);

            txtDNI.Location = new Point(40, 248);
            txtDNI.Size = new Size(235, 25);
            txtDNI.Font = new Font("Segoe UI", 10);

            // 5. BOTÓN REGISTRAR ENTRADA
            btnRegistrar.Location = new Point(40, 300);
            btnRegistrar.Size = new Size(112, 38);
            btnRegistrar.Text = "Entrada";
            btnRegistrar.BackColor = Color.FromArgb(0, 130, 60);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.TextAlign = ContentAlignment.MiddleCenter;
            btnRegistrar.Cursor = Cursors.Hand;

            // 6. BOTÓN REGISTRAR SALIDA DIRECTA
            btnRegistrarSalidaDirecta.Text = "Salida";
            btnRegistrarSalidaDirecta.Location = new Point(163, 300);
            btnRegistrarSalidaDirecta.Size = new Size(112, 38);
            btnRegistrarSalidaDirecta.BackColor = Color.FromArgb(230, 90, 40);
            btnRegistrarSalidaDirecta.ForeColor = Color.White;
            btnRegistrarSalidaDirecta.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnRegistrarSalidaDirecta.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalidaDirecta.FlatAppearance.BorderSize = 0;
            btnRegistrarSalidaDirecta.TextAlign = ContentAlignment.MiddleCenter;
            btnRegistrarSalidaDirecta.Cursor = Cursors.Hand;
            btnRegistrarSalidaDirecta.Click += new EventHandler(this.btnRegistrarSalidaDirecta_Click);
            this.Controls.Add(btnRegistrarSalidaDirecta);

            // 7. CONFIGURACIÓN DEL SISTEMA DE PESTAÑAS
            tabContenedor.Location = new Point(320, 85);
            tabContenedor.Size = new Size(580, 345);
            tabContenedor.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            tabDentroEstacion.Text = "    📍 Dentro de la Estación    ";
            tabDentroEstacion.BackColor = Color.White;

            tabHistorialCompleto.Text = "    📋 Historial General    ";
            tabHistorialCompleto.BackColor = Color.White;

            tabContenedor.Controls.Add(tabDentroEstacion);
            tabContenedor.Controls.Add(tabHistorialCompleto);
            this.Controls.Add(tabContenedor);

            // 8. ESTILIZACIÓN DE LAS TABLAS
            ConfigurarEstiloTabla(dgvDentro);
            ConfigurarEstiloTabla(dgvHistorial);

            dgvDentro.Dock = DockStyle.Fill;
            tabDentroEstacion.Controls.Add(dgvDentro);

            dgvHistorial.Dock = DockStyle.Fill;
            tabHistorialCompleto.Controls.Add(dgvHistorial);

            // 9. BOTONES INFERIORES SCON CORRECCIÓN DE COORDENADAS
            btnExportar.Location = new Point(320, 455);
            btnExportar.Size = new Size(140, 32);
            btnExportar.Text = "📊 Exportar Reporte";
            btnExportar.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnExportar.BackColor = Color.White;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210);
            btnExportar.Cursor = Cursors.Hand;

            btnCerrarSesion.Location = new Point(760, 455);
            btnCerrarSesion.Size = new Size(140, 32);
            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnCerrarSesion.BackColor = Color.White;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(255, 180, 180);
            btnCerrarSesion.ForeColor = Color.FromArgb(200, 40, 40);
            btnCerrarSesion.Cursor = Cursors.Hand;

            dgvVisitas.Visible = false;
        }

        private void ConfigurarEstiloTabla(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.GridColor = Color.FromArgb(240, 242, 245);
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 55, 65);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 235, 218);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 80, 35);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        }

        private void ActualizarDashboard()
        {
            try
            {
                DataTable dt = objetoData.ObtenerEstadisticas();
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblTotalHoy.Text = dt.Rows[0]["TotalHoy"].ToString();
                    lblPresentes.Text = dt.Rows[0]["Presentes"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Dashboard: " + ex.Message);
            }
        }

        private void CargarTableros()
        {
            try
            {
                DataTable dtGeneral = objetoData.BuscarPorDNI(txtDNI.Text.Trim());
                dgvHistorial.DataSource = dtGeneral;

                DataTable dtDentro = dtGeneral.Clone();
                foreach (DataRow fila in dtGeneral.Rows)
                {
                    if (fila["FechaSalida"] == DBNull.Value || string.IsNullOrEmpty(fila["FechaSalida"].ToString()))
                    {
                        dtDentro.ImportRow(fila);
                    }
                }
                dgvDentro.DataSource = dtDentro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar tableros: " + ex.Message);
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            CargarTableros();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, escriba el DNI y el Nombre para registrar la entrada.", "Campos vacíos");
                return;
            }

            bool exito = objetoData.RegistrarVisita(txtDNI.Text.Trim(), txtNombre.Text.Trim());

            if (exito)
            {
                MessageBox.Show("¡Entrada registrada con éxito!", "Control de Accesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDNI.Clear();
                txtNombre.Clear();
                ActualizarDashboard();
                CargarTableros();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la entrada. Verifique los datos.");
            }
        }

        private void btnRegistrarSalidaDirecta_Click(object sender, EventArgs e)
        {
            string dniObjetivo = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dniObjetivo))
            {
                DataGridView tablaActiva = tabContenedor.SelectedIndex == 0 ? dgvDentro : dgvHistorial;
                if (tablaActiva.SelectedRows.Count > 0 && tablaActiva.SelectedRows[0].Cells["DNI"].Value != null)
                {
                    dniObjetivo = tablaActiva.SelectedRows[0].Cells["DNI"].Value.ToString();
                }
            }

            if (string.IsNullOrEmpty(dniObjetivo))
            {
                MessageBox.Show("Por favor, escriba el DNI o seleccione una persona de cualquier tablero para registrar la salida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVisitaEncontrada = -1;
            foreach (DataGridViewRow fila in dgvHistorial.Rows)
            {
                if (fila.Cells["DNI"].Value != null && fila.Cells["DNI"].Value.ToString() == dniObjetivo)
                {
                    var celdaSalida = fila.Cells["FechaSalida"].Value;
                    if (celdaSalida == DBNull.Value || string.IsNullOrEmpty(celdaSalida.ToString()))
                    {
                        idVisitaEncontrada = Convert.ToInt32(fila.Cells["ID"].Value);
                        break;
                    }
                }
            }

            if (idVisitaEncontrada == -1)
            {
                MessageBox.Show("No se encontró ninguna visita activa para el DNI ingresado.", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool exito = objetoData.RegistrarSalida(idVisitaEncontrada);

            if (exito)
            {
                MessageBox.Show("¡Salida registrada con éxito!", "Control de Accesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDNI.Clear();
                txtNombre.Clear();
                ActualizarDashboard();
                CargarTableros();
            }
            else
            {
                MessageBox.Show("Hubo un error al procesar la salida.");
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        // =========================================================================
        // LÓGICA DE DESCARGA DE FORMATO REAL (SPRINT 2 COMPLETADO)
        // =========================================================================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            // 1. Validar que la tabla tenga datos
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en el historial disponibles para descargar.", "Formato Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Configurar la ventana de guardado de Windows
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos de Excel (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            sfd.FileName = $"Reporte_Estacion_Metro_{DateTime.Now:yyyyMMdd}";
            sfd.Title = "Guardar Formato de Reporte de Accesos";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Crear cabeceras del archivo usando los nombres de las columnas del DataGridView
                    string[] headers = new string[dgvHistorial.Columns.Count];
                    for (int i = 0; i < dgvHistorial.Columns.Count; i++)
                    {
                        headers[i] = dgvHistorial.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", headers));

                    // Recorrer las filas y rellenar los datos de los visitantes
                    foreach (DataGridViewRow row in dgvHistorial.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] cells = new string[dgvHistorial.Columns.Count];
                            for (int i = 0; i < dgvHistorial.Columns.Count; i++)
                            {
                                // Limpiar comas internas del texto para no romper las celdas de Excel
                                string val = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                                cells[i] = $"\"{val.Replace("\"", "\"\"")}\"";
                            }
                            sb.AppendLine(string.Join(",", cells));
                        }
                    }

                    // Guardar el archivo en el disco con codificación UTF-8 para que admita eñes y tildes
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("¡El formato de reporte se ha descargado y guardado correctamente!\nYa puede abrirlo directamente con Microsoft Excel.", "Descarga Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al procesar la descarga física del archivo: " + ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}