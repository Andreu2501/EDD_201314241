<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesarrolloJuego.aspx.cs" Inherits="WebApplicationCliente.DesarrolloJuego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Desarrollo del juego</title>
</head>
<body style="background-image:url('imagenes/Tank1.jpg'); height: 626px;"> 
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="DESARROLLO DEL JUEGO"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Administradora.aspx">ATRAS</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Unidades por nivel"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nivel 0"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtnivel0" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Nivel 1"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtnivel1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Nivel 2"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtnivel2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Nivel 3"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtnivel3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Mandar Limites" />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Tamaño del tablero"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Columnas"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtcolumnas" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Filas"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtfilas" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Mandar Tamaños" />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Tipo del Juego"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Normal</asp:ListItem>
            <asp:ListItem>Tiempo</asp:ListItem>
            <asp:ListItem>Base</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Normal"></asp:Label>
        <asp:TextBox ID="txtnormal" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Normal" />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Tiempo"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Cuantos minutos:"></asp:Label>
        <asp:TextBox ID="txttiempo" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mandar tiempo" />
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
        </asp:Timer>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server"> 
          <ContentTemplate>  
         <asp:Label ID="Labeltiempo0" runat="server" ></asp:Label>
        
               </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
             </Triggers>
              </asp:UpdatePanel>
         
       
        <br />
        <br />
        <br />
        <asp:Label ID="Base" runat="server" Text="Base"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Base0" runat="server" Text="Columna"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtcolumna" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Base1" runat="server" Text="Fila"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtfila" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Mandar Base" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
