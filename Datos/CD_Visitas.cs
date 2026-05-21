using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms; // Para los mensajes de error

namespace Proyecto_ControlAcceso_Equipo4_Sprint1.Datos
{
    public class CD_Visitas
    {
        // 1. MÉTODO PARA REGISTRAR (NUEVO)
        // Este método inserta los datos en la tabla que creaste por SQL
        public bool RegistrarVisita(string dni, string nombre)
        {
            bool respuesta = false;
            using (SQLiteConnection con = new SQLiteConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    // El ID es AUTOINCREMENT, por eso no lo ponemos aquí.
                    // FechaSalida se queda NULL (vacío) hasta que la persona se retire.
                    string sql = "INSERT INTO Visitas (DNI, Nombre, FechaEntrada) VALUES (@dni, @nombre, @fecha)";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        // Formato compatible con SQLite: Año-Mes-Día Hora:Minuto:Segundo
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            respuesta = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar visita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return respuesta;
        }

        // 2. MÉTODO PARA EL DASHBOARD (ESTADÍSTICAS)
        public DataTable ObtenerEstadisticas()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    // Cuenta las visitas de hoy y las personas que aún no han salido (FechaSalida es NULL)
                    string sql = @"SELECT 
                        (SELECT COUNT(*) FROM Visitas WHERE date(FechaEntrada) = date('now')) as TotalHoy,
                        (SELECT COUNT(*) FROM Visitas WHERE FechaSalida IS NULL) as Presentes";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        // 3. MÉTODO PARA EL BUSCADOR INTELIGENTE
        public DataTable BuscarPorDNI(string dni)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    // Busca por DNI aproximado (LIKE)
                    string sql = "SELECT * FROM Visitas WHERE DNI LIKE @dni || '%' ORDER BY FechaEntrada DESC";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@dni", dni);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Buscador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        // 4. MÉTODO PARA REGISTRAR SALIDA (EXTRA)
        // Útil para cuando la persona se retira del edificio
        public bool RegistrarSalida(int idVisita)
        {
            bool respuesta = false;
            using (SQLiteConnection con = new SQLiteConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE Visitas SET FechaSalida = @fecha WHERE ID = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@id", idVisita);

                        if (cmd.ExecuteNonQuery() > 0) respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar salida: " + ex.Message);
                }
            }
            return respuesta;
        }
    }
}