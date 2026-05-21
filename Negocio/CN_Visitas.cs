using System;
using System.Data;
using Proyecto_ControlAcceso_Equipo4_Sprint1.Datos; // Conecta con tu CD_Visitas

namespace Proyecto_ControlAcceso_Equipo4_Sprint1.Negocio
{
    public class CN_Visitas
    {
        // Instancia directa a tu clase de datos original
        private CD_Visitas objetoData = new CD_Visitas();

        // 1. Capa de Negocio para el Dashboard
        public DataTable ObtenerEstadisticas()
        {
            return objetoData.ObtenerEstadisticas();
        }

        // 2. Capa de Negocio para Registrar
        public bool RegistrarVisita(string dni, string nombre)
        {
            // Regla de negocio: No permitir campos vacíos o DNI falsos cortos
            if (string.IsNullOrWhiteSpace(dni) || dni.Length < 8)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            return objetoData.RegistrarVisita(dni, nombre);
        }

        // 3. Capa de Negocio para el Buscador Inteligente
        public DataTable BuscarPorDNI(string dni)
        {
            return objetoData.BuscarPorDNI(dni);
        }

        // 4. Capa de Negocio para Registrar Salida (El método extra que tienes)
        public bool RegistrarSalida(int idVisita)
        {
            if (idVisita <= 0)
            {
                return false;
            }
            return objetoData.RegistrarSalida(idVisita);
        }
    }
}