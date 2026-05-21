using System;
using System.Data;
using System.Data.SQLite;

namespace Proyecto_ControlAcceso_Equipo4_Sprint1
{
    public class CD_Usuario
    {
        public bool ValidarUsuario(string user, string pass)
        {
            bool existe = false;

            // Usa la clase Conexion que está en el otro archivo
            using (SQLiteConnection con = new SQLiteConnection(Conexion.cadena))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @user AND Clave = @pass";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                        if (resultado > 0)
                        {
                            existe = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error en base de datos: " + ex.Message);
                }
            }
            return existe;
        }
    }
}