using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TrabajoPractico6
{
    public class GestionProductos
    {
        public GestionProductos()
        {
        }

        private DataTable obtenerTabla(String nombre, String consultaSql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.obtenerAdaptador(consultaSql);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }
        public DataTable obtenerProductos()
        {
            String nombreTabla = "Productos";
            String consultaSQL = "SELECT * FROM Productos";
            return obtenerTabla(nombreTabla, consultaSQL);
        }
        private void armarParametrosProductosEliminar(ref SqlCommand comando, Producto producto)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParametros.Value = producto.IdProducto;
        }
        private void armarParametrosProductos(ref SqlCommand comando, Producto producto)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParametros.Value = producto.IdProducto;
            sqlParametros = comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar, 40);
            sqlParametros.Value = producto.NombreProducto;
            sqlParametros = comando.Parameters.Add("@CantidadPorUnidad", SqlDbType.NVarChar, 20);
            sqlParametros.Value = producto.CantidadPorUnidad;
            sqlParametros = comando.Parameters.Add("@PrecioUnidad", SqlDbType.Money);
            sqlParametros.Value = producto.PrecioUnidad;
        }
        public bool actualizarProducto(Producto producto)
        {
            String sp = "spActualizarProducto";
            SqlCommand comando = new SqlCommand();
            armarParametrosProductos(ref comando, producto);
            AccesoDatos ad = new AccesoDatos();
            int filasAfectadas = ad.ejecutarProcedimientoAlmacenado(comando, sp);
            if (filasAfectadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool eliminarProducto(Producto producto)
        {
            String sp = "spEliminarProducto";
            SqlCommand comando = new SqlCommand();
            armarParametrosProductosEliminar(ref comando, producto);
            AccesoDatos ad = new AccesoDatos();
            int filasAfectadas = ad.ejecutarProcedimientoAlmacenado(comando, sp);
            if (filasAfectadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}