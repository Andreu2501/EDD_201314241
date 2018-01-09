using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
namespace WebApplicationCliente
{
    public partial class Reportes : System.Web.UI.Page
    {
         WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
             string path0 = "C:\\ARCHIVOSDOT\\Matriz0.png";
             string path1 = "C:\\ARCHIVOSDOT\\Matriz1.png";
             string path2 = "C:\\ARCHIVOSDOT\\Matriz2.png";
             string path3 = "C:\\ARCHIVOSDOT\\Matriz3.png";
             
             Process.Start(path0);
             Process.Start(path1);
             Process.Start(path2);
             Process.Start(path3);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            servicio.graficarUsuario();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            servicio.graficarEspejo();
            string path = "C:\\ARCHIVOSDOT\\usuarios.png";

            Process.Start(path);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            
           string path = "C:\\ARCHIVOSDOT\\Top_Ganadas.png";

            Process.Start(path);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string path = "C:\\ARCHIVOSDOT\\Top_Destruidas.png";
            Process.Start(path);
        }

          

        protected void Button6_Click(object sender, EventArgs e)
        {
            servicio.Reporte1();//sobrevivientes
            //string path0 = "C:\\ARCHIVOSDOT\\Matriz0.png";
            //string path1 = "C:\\ARCHIVOSDOT\\Matriz1.png";
            //string path2 = "C:\\ARCHIVOSDOT\\Matriz2.png";
            //string path3 = "C:\\ARCHIVOSDOT\\Matriz3.png";

            //Process.Start(path0);
            //Process.Start(path1);
            //Process.Start(path2);
           // Process.Start(path3);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            servicio.Reportede0();//destruidos
            string path0 = "C:\\ARCHIVOSDOT\\Matriz0.png";
            string path1 = "C:\\ARCHIVOSDOT\\Matriz1.png";
            string path2 = "C:\\ARCHIVOSDOT\\Matriz2.png";
            string path3 = "C:\\ARCHIVOSDOT\\Matriz3.png";

            Process.Start(path0);
            Process.Start(path1);
            Process.Start(path2);
            Process.Start(path3);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            servicio.generarTOPContactos();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
             string path = "C:\\ARCHIVOSDOT\\contactos.png";

            Process.Start(path);
        }

       
    }
}