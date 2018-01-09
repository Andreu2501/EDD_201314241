using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class ABCJUEGO : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nickname_base = txtnickname_base.Text;
            string nickname_oponente = txtnickname_oponente.Text;
            string desplegadas = txtdesplegadas.Text;
            string sobrevivientes = txtsobrevivientes.Text;
            string destruidas = txtdestruidas.Text;
            string gano = txtgano.Text;

            int des = Convert.ToInt32(desplegadas);
            int sob = Convert.ToInt32(sobrevivientes);
            int destru = Convert.ToInt32(destruidas);
            int gan = Convert.ToInt32(gano);

    
            servicio.insertarjuego(nickname_base, nickname_oponente, des, sob, destru, gan);

            txtnickname_base.Text = string.Empty;
            txtnickname_oponente.Text = string.Empty;
            txtdesplegadas.Text = string.Empty;
            txtdestruidas.Text = string.Empty;
            txtgano.Text = string.Empty;
            txtsobrevivientes.Text = string.Empty;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string nickname_base = txtnickname_base.Text;
            string nickname_oponente = txtnickname_oponente.Text;
            string desplegadas = txtdesplegadas.Text;
            string sobrevivientes = txtsobrevivientes.Text;
            string destruidas = txtdestruidas.Text;
            string gano = txtgano.Text;

            int des = Convert.ToInt32(desplegadas);
            int sob = Convert.ToInt32(sobrevivientes);
            int destru = Convert.ToInt32(destruidas);
            int gan = Convert.ToInt32(gano);

            servicio.modificarJuego(nickname_base, nickname_oponente, des, sob, destru, gan);
            txtnickname_base.Text = string.Empty;
            txtnickname_oponente.Text = string.Empty;
            txtdesplegadas.Text = string.Empty;
            txtdestruidas.Text = string.Empty;
            txtsobrevivientes.Text = string.Empty;
            txtgano.Text = string.Empty;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string nickname_base = txtnickname_base.Text;
            string nickname_oponente = txtnickname_oponente.Text;
            servicio.eliminarJuego(nickname_base, nickname_oponente);
            txtnickname_base.Text = string.Empty;
            txtnickname_oponente.Text = string.Empty;
        }
    }
}