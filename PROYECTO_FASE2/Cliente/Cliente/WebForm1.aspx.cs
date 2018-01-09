using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Cliente
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       static serviciosw.ServicioWeb conexion = new serviciosw.ServicioWeb();
       

        string administrador = "edd";
        string pass = "vacaciones";
        protected void Page_Load(object sender, EventArgs e)
        {

            
            
            
           

        }
      
        protected void Button1_Click(object sender, EventArgs e)

        {
           
            
            if (txtusuario.Text == administrador && txtpass.Text == pass)
            {

                Server.Transfer("Juego.aspx", true);

            }
            else { label1.Visible = true; }
            
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

