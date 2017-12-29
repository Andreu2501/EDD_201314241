<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administradora.aspx.cs" Inherits="WebApplicationCliente.Cargas" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador</title>
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet" />
     <link href="Bootstrap/Style.css" rel="stylesheet" />
    <style type="text/css">
        #form1 {
            height: 225px;
        }
    </style>
</head>
<body style="background-image:url('imagenes/Tank1.jpg'); height: 626px;"> 
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="Black" Text="ADMINISTRADOR"></asp:Label>
    
    </div>
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server" BackColor="Red" NavigateUrl="~/WebForm1.aspx">ATRAS</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" BackColor="#FFFFCC" ForeColor="Blue" NavigateUrl="~/USUARIOS.aspx">ABC USUARIOS</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" BackColor="#FFFFCC" ForeColor="Blue" NavigateUrl="~/ABCJUEGO.aspx">ABC JUEGOS</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" BackColor="#FFFFCC" ForeColor="Blue" NavigateUrl="~/Carga.aspx">CARGA DE DATOS</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" BackColor="#FFFFCC" ForeColor="Blue" NavigateUrl="~/Reportes.aspx">REPORTES</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
