using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico6
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) {
                cargarGridViewProductos();
            }
        }

        public void cargarGridViewProductos()
        {
            GestionProductos gestionProductos = new GestionProductos();
            grdvProductos.DataSource = gestionProductos.obtenerProductos();
            grdvProductos.DataBind();
        }

        protected void grdvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvProductos.PageIndex = e.NewPageIndex;
            cargarGridViewProductos();
        }

        protected void grdvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String s_IdProducto = ((Label)grdvProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;

            Producto producto = new Producto();
            producto.IdProducto = Convert.ToInt32(s_IdProducto);

            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.eliminarProducto(producto);

            cargarGridViewProductos();
        }

        protected void grdvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdvProductos.EditIndex = e.NewEditIndex;
            cargarGridViewProductos();
        }

        protected void grdvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdvProductos.EditIndex = -1;
            cargarGridViewProductos();
        }

        protected void grdvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String s_IdProducto = ((Label)grdvProductos.Rows[e.RowIndex].FindControl("lbl_eit_IdProducto")).Text;
            String s_NombreProducto = ((TextBox)grdvProductos.Rows[e.RowIndex].FindControl("txt_eit_NombreProducto")).Text;
            String s_CantidadPorUnidad = ((TextBox)grdvProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadPorUnidad")).Text;
            String s_PrecioUnidad = ((TextBox)grdvProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad")).Text;

            Producto producto = new Producto();
            producto.IdProducto = Convert.ToInt32(s_IdProducto);
            producto.NombreProducto = s_NombreProducto;
            producto.CantidadPorUnidad = s_CantidadPorUnidad;
            producto.PrecioUnidad = Convert.ToDecimal(s_PrecioUnidad);

            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.actualizarProducto(producto);

            grdvProductos.EditIndex = -1;
            cargarGridViewProductos();
        }
    }
}