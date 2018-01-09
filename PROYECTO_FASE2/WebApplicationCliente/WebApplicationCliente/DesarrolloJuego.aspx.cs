using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class DesarrolloJuego : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            
                string j = txttiempo.Text;
                int m = Convert.ToInt32(j);
                Session["Timer"] = DateTime.Now.AddMinutes(m).ToString();

                servicio.PARAMETRO_CRONOMETRO(m);
            
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string nivel0 = txtnivel0.Text;
            string nivel1 = txtnivel1.Text;
            string nivel2 = txtnivel2.Text;
            string nivel3 = txtnivel3.Text;
            int M0=Convert.ToInt32(nivel0);
            int M1 = Convert.ToInt32(nivel1);
            int M2 = Convert.ToInt32(nivel2);
            int M3 = Convert.ToInt32(nivel3);
            servicio.limites_nivel(M0,M1,M2,M3);
            txtnivel0.Text = string.Empty;
            txtnivel1.Text = string.Empty;
            txtnivel2.Text = string.Empty;
            txtnivel3.Text = string.Empty;
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string columnas = txtcolumnas.Text;
            string filas = txtfilas.Text;
            int col = Convert.ToInt32(columnas);
            int fil = Convert.ToInt32(filas);
            servicio.LIMITE_COLUMNAS_FILAS(col, fil);
            txtcolumnas.Text = string.Empty;
            txtfilas.Text = string.Empty;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string Normal = txtnormal.Text;


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string columna_base = txtcolumna.Text;
            string fila_base = txtfila.Text;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elegido = DropDownList1.SelectedItem.ToString();
            servicio.MODO_JUEGO(elegido);


        }
        

      

       
       
    }
}