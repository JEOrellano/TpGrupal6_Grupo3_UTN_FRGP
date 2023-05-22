using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TrabajoPractico6
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                cargarGridViewProductosSeleccionados();
            }
        }
        private void cargarGridViewProductosSeleccionados()
        {
            GestionProductos gestionProductos = new GestionProductos();
            grdvSeleccionarProductos.DataSource = gestionProductos.obtenerProductos();
            grdvSeleccionarProductos.DataBind();
        }

        protected void grdvSeleccionarProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvSeleccionarProductos.PageIndex = e.NewPageIndex;
            cargarGridViewProductosSeleccionados();
        }

        protected void grdvSeleccionarProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectProducto")
            {
                int fila = Convert.ToInt32(e.CommandArgument);

                String s_IdProducto = ((Label)grdvSeleccionarProductos.Rows[fila].FindControl("lbl_it_IdProducto")).Text;
                String s_NombreProducto = ((Label)grdvSeleccionarProductos.Rows[fila].FindControl("lbl_it_NombreProducto")).Text;
                String s_IdProveedor = ((Label)grdvSeleccionarProductos.Rows[fila].FindControl("lbl_it_IdProveedor")).Text;
                String s_PrecioUnidad = ((Label)grdvSeleccionarProductos.Rows[fila].FindControl("lbl_it_PrecioUnidad")).Text;
                lblMensaje.Text = "Producto agregado: " + s_NombreProducto;

                if (Session["TablaProductoSeleccion"] == null)
                {
                    Session["TablaProductoSeleccion"] = crearTabla();
                }
                agreagrFila((DataTable)Session["TablaProductoSeleccion"], s_IdProducto, s_NombreProducto, s_IdProveedor, s_PrecioUnidad);
            }
        }
        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("IdProducto", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("NombreProducto", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("IdProveedor", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("PrecioUnidad", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }
        public void agreagrFila(DataTable TablaProductoSeleccion, String s_IdProducto, String s_NombreProducto, String s_IdProveedor, String s_PrecioUnidad)
        {
            DataRow dr = TablaProductoSeleccion.NewRow();
            dr["IdProducto"] = s_IdProducto;
            dr["NombreProducto"] = s_NombreProducto;
            dr["IdProveedor"] = s_IdProveedor;
            dr["PrecioUnidad"] = s_PrecioUnidad;
            TablaProductoSeleccion.Rows.Add(dr);
        }
    }
}