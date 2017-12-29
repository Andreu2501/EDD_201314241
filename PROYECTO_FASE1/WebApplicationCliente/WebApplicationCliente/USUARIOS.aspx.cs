using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCliente
{
    public partial class USUARIOS : System.Web.UI.Page
    {

         WScliente.ServicioWebSoapClient servicio = new WScliente.ServicioWebSoapClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtingresar_Click(object sender, EventArgs e)
        {
            
           
            
            
            string nickname = txtnickname.Text;
            string contraseña = txtcontraseña.Text;
            string correo = txtcorreo.Text;
            string conectado = txtconectado.Text;

            int valorConectado = Convert.ToInt32(conectado);

            servicio.insertarUsuario(nickname, contraseña, correo, valorConectado);

            
            
        }

        protected void txtmodificar_Click(object sender, EventArgs e)
        {
            string nickname_modificar = txtnickname_modificar.Text;
            string nickname = txtnickname.Text;
            string contraseña = txtcontraseña.Text;
            string correo = txtcorreo.Text;
            string conectado = txtconectado.Text;

            int valorConectado = Convert.ToInt32(conectado);

            servicio.modificarUsuario(nickname_modificar, nickname, contraseña, correo, valorConectado);

        }

        protected void bteliminar_Click(object sender, EventArgs e)
        {
            string nickname_eliminar = txteliminar.Text;
            servicio.eliminarUsuario(nickname_eliminar);
          

        }
    }
}