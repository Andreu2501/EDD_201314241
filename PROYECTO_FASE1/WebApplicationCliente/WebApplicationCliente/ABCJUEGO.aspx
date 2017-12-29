<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABCJUEGO.aspx.cs" Inherits="WebApplicationCliente.ABCJUEGO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ABCJUEGO</title>
    
</head>
    <body style="background-image:url('imagenes/Tank1.jpg'); height: 626px;"> 
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" BackColor="Gray" Text="ABCJUEGOS"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Administradora.aspx" ViewStateMode="Enabled">Atras</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nickname base"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtnickname_base" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nickname oponente"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtnickname_oponente" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Unidades desplegadas"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtdesplegadas" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Unidades sobrevivientes"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtsobrevivientes" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Unidades destruidas"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtdestruidas" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Gano si 1 /no 0"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtgano" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ingresar" />
&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="modificar" />
&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="eliminar" />
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Insertar Se llenan todos los campos"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Para Eliminar, solo se tiene que llenar el campo nickname_base y nickname_oponente"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Modificar se llenan todos los campos"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
