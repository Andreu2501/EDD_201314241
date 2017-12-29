<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationCliente.WebForm1" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet" />
     <link href="Bootstrap/Style.css" rel="stylesheet" />
</head>
<body style="background-image:url('imagenes/Tank1.jpg'); height: 626px;"> 
  
               
                
         <form id="form1" runat="server">
        <div class="panel-img">
            <div style="position:absolute; z-index:1; top: 102px; left: 11px;" id="layer1">
                <div class="modal-body" style="margin: 30px 0px 0px 400px; top: 23px; left: 66px; width: 372px; height: 260px;">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="form-group">
                                <label for="Usuario" class="control-label">usuario</label>
                               
                              
                                
                                <asp:TextBox ID="txtusuario" placeholder="usuario"  runat="server" class="form-control"></asp:TextBox>
                               
                          
                                <label for="Contraseña" class="control-label">Contraseña</label>
                                  <asp:TextBox ID="txtpass" placeholder="pass" TextMode="Password" runat="server"  class="form-control" ></asp:TextBox>
                               
                                
       
                               
                            </div>
                            <asp:Button ID="Login" runat="server" OnClick="Button1_Click" class="btn btn-success btn-block" Text="Login"/>
                            <asp:Label ID="label1" Visible="False" runat="server" Text="Intentelo de nuevo" BackColor="White" ForeColor="Red"></asp:Label>
                               
                </div>

           
                </div>
                
                </div>
                 
                  </div>
                
                </div>
        </form>
  
               
                
</body>
</html>
