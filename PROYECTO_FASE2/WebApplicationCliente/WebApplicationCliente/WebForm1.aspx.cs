using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    
            
    public partial class WebForm1 : System.Web.UI.Page
    {


        static WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
       
        
        string administrador = "1";
        string pass = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            bool bandera = servicio.VerificarExistenciaUsuario(txtusuario.Text, txtpass.Text);
        
          
         
            
            if (bandera==true)
            {

                Server.Transfer("Juego.aspx", true);

            }
            else if (txtusuario.Text == administrador && txtpass.Text == pass)
            {
                Server.Transfer("Administradora.aspx", true);
            }
            else { label1.Visible = true; }

           

           

        }
    }
}