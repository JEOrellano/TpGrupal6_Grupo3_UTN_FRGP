using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TrabajoPractico6
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TablaProductoSeleccion"] != null)
            {
                grdvMostrarProductos.DataSource = (DataTable)Session["TablaProductoSeleccion"];
                grdvMostrarProductos.DataBind();
            }
        }
    }
}