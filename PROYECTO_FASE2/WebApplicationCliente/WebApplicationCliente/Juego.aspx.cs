using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class Juego : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           

           int n= servicio.MANDAR_CRONOMETRO();
           if (!IsPostBack)
           {
               Session["Timer"] = DateTime.Now.AddMinutes(n).ToString();
               labelmodo.Text = servicio.ENVIAR_MODO();
               labelnivel0.Text = servicio.mandarlimite0().ToString();
               labelnivel1.Text = servicio.mandarlimite1().ToString();
               labelnivel2.Text = servicio.mandarlimite2().ToString();
               labelnivel3.Text = servicio.mandarlimite3().ToString();

               LABELNOMBRE.Text = servicio.jugadorNOMBRE();

           }
           else { LABELNOMBRE.Text = servicio.jugadorNOMBRE(); }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string jugador = servicio.jugadorNOMBRE();
            string columna = x.Text;
            string fila = y.Text;
            string unidad = txtunidad.Text;
           
            servicio.InsertarMatrizJuego(columna, fila, unidad, jugador);

            txtunidad.Text = string.Empty;
            x.Text = string.Empty;
            y.Text = string.Empty;

            DropDownList1.Items.Add(columna);
            DropDownList2.Items.Add(fila);
            DropDownList3.Items.Add(unidad);
            LABELNOMBRE.Text = servicio.jugadorNOMBRE();
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


        
        


             
            Image1.ImageUrl="C:\\inetpub\\wwwroot\\ASP\\R\\Matriz0.png";

          


        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Compare(DateTime.Now, DateTime.Parse(Session["Timer"].ToString())) < 0)
                {
                    Labeltiempo0.Text = "Cronometro :" + ((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalMinutes)
                        .ToString() + "Minutos" + (((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds) % 60)
                        .ToString() + "Segundos";

                }
                else
                {
                    Labeltiempo0.Text = "tiempo terminado";
                }
            }
            catch (Exception x)
            {

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            bool bandera;
            string x = atacarx.Text;
            string y = atacary.Text;
            string nivel = atacarnivel.Text;
            int n=Convert.ToInt32(nivel);


            bandera= servicio.ataques(x, y, n);
          
           x = string.Empty;
           y = string.Empty;
           nivel = string.Empty;

         LabelATAQUE.Text = servicio.mensajeAtaque();
         if (bandera == true)
         {
             msjperdedor.Visible = true;
             msjperdedor.Text = servicio.mensajePerdedor();
         }

        }

       
    }
}