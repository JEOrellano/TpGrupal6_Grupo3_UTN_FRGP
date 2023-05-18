using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TrabajoPractico6
{
    public class AccesoDatos
    {
        private static String rutaBDNeptuno = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
        public AccesoDatos()
        {

        }
        public SqlConnection obtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDNeptuno);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter obtenerAdaptador(String consultaSql)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, obtenerConexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int ejecutarProcedimientoAlmacenado(SqlCommand comando, String nombreSP)
        {
            int filasCambiadas;
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            filasCambiadas = cmd.ExecuteNonQuery();
            conexion.Close();
            return filasCambiadas;
        }
    }
}