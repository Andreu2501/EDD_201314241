using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class Juego : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string columna = x.Text;
            string fila = y.Text;
            string unidad = txtunidad.Text;
            string jugador=txtjugador.Text;

            servicio.InsertarMatrizJuego(columna, fila, unidad, jugador);

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            
            string path3 = "C:\\ARCHIVOSDOT\\Matriz3.png";

            
            Process.Start(path3);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string path2 = "C:\\ARCHIVOSDOT\\Matriz2.png";


            Process.Start(path2);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            string path1 = "C:\\ARCHIVOSDOT\\Matriz1.png";


            Process.Start(path1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            string path0 = "C:\\ARCHIVOSDOT\\Matriz0.png";


            Process.Start(path0);
        }
    }
}