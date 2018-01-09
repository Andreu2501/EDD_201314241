using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplicationCliente
{
    public partial class TablaHash : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            servicio.insertarTablaHash();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string path3 = "C:\\ARCHIVOSDOT\\TablaHash.png";

            Process.Start(path3);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string nickname_eliminar = txteliminar.Text;
            servicio.eliminarTablaHash(nickname_eliminar);
        }
    }
}