using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class Carga : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            servicio.leercsvUsuarios();
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            servicio.leercsvJuegos_usuarios();
           
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            servicio.leercsvTablero();
        }
    }
}