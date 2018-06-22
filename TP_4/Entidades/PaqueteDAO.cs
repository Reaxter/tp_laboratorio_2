using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        public static bool Insertar(Paquete p)
        {
            bool returnValue = false;
            try
            {
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando = new SqlCommand(String.Format("INSERT into [correo-sp-2017].[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno]) VALUES ('{0}','{1}','Alejandro Ledesma')", p.DireccionEntrega, p.TrackingID), PaqueteDAO._conexion);
                if (PaqueteDAO._comando.ExecuteNonQuery() != 0)
                    returnValue = true;
            }
            catch (Exception e)
            { 
                throw e;
            }
            finally
            {
                if (PaqueteDAO._conexion.State == ConnectionState.Open)
                    PaqueteDAO._conexion.Close();
            }
            return returnValue;
        }
        static PaqueteDAO()
        { 
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.conexion);
        }
    }
}