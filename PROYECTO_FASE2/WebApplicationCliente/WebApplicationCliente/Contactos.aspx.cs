using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class Contactos : System.Web.UI.Page
    {
        WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text;
            string nickname = txtnickname.Text;
            string pass = txtpass.Text;
            string correo = txtcorreo.Text;
            servicio.agregarcontactopadre(usuario, nickname, correo,pass);

            
        }

        protected void txteliminar_Click(object sender, EventArgs e)
        {
             string usuario = txtusuario.Text;
             string nickname = txtnickname.Text;
             servicio.eliminarContacto(usuario, nickname);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text;
            string nickname = txtnickname.Text;
            string pass = txtpass.Text;
            string correo = txtcorreo.Text;
            string nickname_viejo = txtnickname_viejo.Text;
            servicio.ModificarContacto(usuario, nickname_viejo, nickname, correo, pass);
        }
    }
}