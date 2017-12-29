<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="WebApplicationCliente.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Juego</title>
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet" />
     <link href="Bootstrap/Style.css" rel="stylesheet" />
    </head>
<body style="background-image:url('imagenes/15.jpg'); height: 626px;"> 
    <form id="form1" runat="server">
    <div class="panel-img">
         <asp:HyperLink ID="HyperLink5" runat="server" BackColor="#6600FF" NavigateUrl="~/WebForm1.aspx">ATRAS</asp:HyperLink>
         <div style="position:absolute; z-index:1; top: 32px; left: 1151px; width: 302px; height: 399px; margin-top: 0px;" id="LAYER5">
               <asp:Label ID="Label1" runat="server" Text="Movimiento de Naves" Width="138px"></asp:Label>
               <br />
               <asp:Label ID="Label4" runat="server" Text="Jugador:"></asp:Label>
               <br />
               <asp:TextBox ID="txtjugador" runat="server" Width="173px"></asp:TextBox>
               &nbsp;<br />
               <asp:Label ID="Label2" runat="server" Text="Coordenada en x:"></asp:Label>
               <br />
               <br />
               <asp:TextBox ID="x" runat="server" Width="173px"></asp:TextBox>
               <br />
               <br />
               <asp:Label ID="Label3" runat="server" Text="Coordenada en y:"></asp:Label>
               <br />
               <br />
               <asp:TextBox ID="y" runat="server" Width="173px"></asp:TextBox>
               <br />
               <br />
               <asp:Label ID="Label5" runat="server" Text="Nombre Unidad:"></asp:Label>
               <br />
               <br />
               <asp:TextBox ID="txtunidad" runat="server" Width="173px"></asp:TextBox>
               <br />
               <br />
               <br />
               <asp:Button ID="Button1" runat="server" BackColor="#669900" OnClick="Button1_Click" Text="Aceptar" />
            </div> 

        <div style="position:absolute; z-index:1; top: 306px; left: 13px; width: 302px; height: 250px;" id="layer1">
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Barcos" Width="288px" />
            </div>
    
        <div style="position:absolute; z-index:1; top: 48px; left: 9px; width: 302px; height: 250px;" id="layer2">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Satelites" Width="292px" />
            </div>
         <div style="position:absolute; z-index:1; top: 50px; left: 356px; width: 302px; height: 250px;" id="layer3">
             <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Aviones" Width="299px" />
            </div>
           <div style="position:absolute; z-index:1; top: 312px; left: 356px; width: 302px; height: 250px; margin-top: 0px;" id="layer4">
               <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Submarinos" Width="298px" />
            </div> 

    </div>
    </form>
</body>
</html>
