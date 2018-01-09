<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="WebApplicationCliente.Juego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Juego</title>
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet" />
     <link href="Bootstrap/Style.css" rel="stylesheet" />
    </head>
<body style="background-image:url('imagenes/15.jpg'); height: 676px;"> 
    <form id="form1" runat="server">
    <div class="panel-img">
         <asp:HyperLink ID="HyperLink5" runat="server" BackColor="#6600FF" NavigateUrl="~/WebForm1.aspx">ATRAS</asp:HyperLink>
         <div style="position:absolute; z-index:1; top: 44px; left: 987px; margin-top: 0px; height: 484px; width: 203px;" id="LAYER5">
               <asp:Label ID="Label1" runat="server" Text="Movimiento de Naves" Width="138px"></asp:Label>
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
               <asp:Label ID="Label4" runat="server" Text="Jugador:"></asp:Label>
               <br />
               <asp:Label ID="LABELNOMBRE" runat="server"></asp:Label>
               &nbsp;<br />
               <asp:Label ID="Label2" runat="server" Text="Coordenada en x:"></asp:Label>
               <br />
               <asp:TextBox ID="x" runat="server" Width="173px"></asp:TextBox>
               <br />
               <asp:Label ID="Label3" runat="server" Text="Coordenada en y:"></asp:Label>
               <br />
               <asp:TextBox ID="y" runat="server" Width="173px"></asp:TextBox>
               <br />
               <asp:Label ID="Label5" runat="server" Text="Nombre Unidad:"></asp:Label>
               <br />
               <asp:TextBox ID="txtunidad" runat="server" Width="173px"></asp:TextBox>
               <br />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="Button1" runat="server" BackColor="#669900" OnClick="Button1_Click" Text="Mover" />
               <br />
               <asp:Label ID="Label10" runat="server" Text="Coordenada en x:"></asp:Label>
               <br />
               <asp:TextBox ID="atacarx" runat="server" Width="173px"></asp:TextBox>
               <br />
               <asp:Label ID="Label11" runat="server" Text="Coordenada en y:"></asp:Label>
               <br />
               <asp:TextBox ID="atacary" runat="server" Width="173px"></asp:TextBox>
               <br />
               <asp:Label ID="Label12" runat="server" Text="Nivel:"></asp:Label>
               <br />
               <asp:TextBox ID="atacarnivel" runat="server" Width="173px"></asp:TextBox>
               <br />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="Button6" runat="server" BackColor="#669900" OnClick="Button6_Click" Text="Atacar" />
               <br />
               <asp:Label ID="LabelATAQUE" runat="server"></asp:Label>
               <br />
               <br />
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
               <asp:Image ID="Image1" runat="server" Height="217px" Width="298px" />
            </div> 

         <br />
         <asp:Label ID="Label8" runat="server" Text="MODO DEL JUEGO"></asp:Label>
         <br />
         <asp:Label ID="labelmodo" runat="server"></asp:Label>

         <br />
         <asp:Label ID="Label9" runat="server" Text="Naves Disponibles"></asp:Label>
         <br />
         <asp:Label ID="labelmodo0" runat="server">nivel0:</asp:Label>
         <asp:Label ID="labelnivel0" runat="server"></asp:Label>
         <br />
         <asp:Label ID="labelmodo1" runat="server">nivel1:</asp:Label>
         <asp:Label ID="labelnivel1" runat="server"></asp:Label>
         <br />
         <asp:Label ID="labelmodo2" runat="server">nivel2:</asp:Label>
         <asp:Label ID="labelnivel2" runat="server"></asp:Label>
         <br />
         <asp:Label ID="labelmodo3" runat="server">nivel3:</asp:Label>
         <asp:Label ID="labelnivel3" runat="server"></asp:Label>
         <br />
         <br />
         <asp:Label runat="server" TabIndex="10" Text="Columnas"></asp:Label>
         <br />
         <br />
         

         <asp:DropDownList ID="DropDownList1" runat="server">
         </asp:DropDownList>
         <br />
         <br />
         <asp:Label ID="Label6" runat="server" TabIndex="10" Text="Filas"></asp:Label>
         <br />
         <br />
         

         <asp:DropDownList ID="DropDownList2" runat="server">
         </asp:DropDownList>
         <br />
         <br />
         <asp:Label ID="Label7" runat="server" TabIndex="10" Text="Naves en el tablero"></asp:Label>
         <br />
         <br />
         

         <asp:DropDownList ID="DropDownList3" runat="server">
         </asp:DropDownList>
         <br />
         <br />
         <br />
         <asp:Label ID="msjperdedor" runat="server" BackColor="Red" Height="50px" Visible="False" Width="127px"></asp:Label>
         <br />
         <br />
         <asp:Label ID="Label13" runat="server" Text="Consola"></asp:Label>
         <br />
         <asp:TextBox ID="consola" runat="server" Height="192px" Width="343px"></asp:TextBox>
         

    </div>
    </form>
</body>
</html>
