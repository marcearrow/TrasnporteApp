<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row justify-content-center ">
            <div class="col-sm-6 align-content-center">
                <div class="card">
                    <div class="card-body">
                        <br />
                        <h5 class="card-title text-center">Ingresar</h5>
                        <br />
                        <div class="form-group">
                            <label for="rutInput">Rut: </label>
                            <asp:TextBox ID="rutInput" CssClass="form-control" placeholder="ingrese su rut" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvRut" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar un rut"
                                ControlToValidate="rutInput" EnableClientScript="False"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-group">
                            <label for="contraseñaInput">Contraseña: </label>
                            <asp:TextBox ID="contraseniaInput" CssClass="form-control" placeholder="ingrese su contraseña" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvContrasenia" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar una contraseña"
                                ControlToValidate="contraseniaInput" EnableClientScript="False"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        
                        <asp:Literal ID="LtMensaje" runat="server"></asp:Literal>
                        <br />
                        <br />
                        <asp:Button ID="cmdSesion" CssClass="btn btn-primary " runat="server" Text="Iniciar Sesión" OnClick="cmdSesion_Click" />

                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/jquery-3.0.0.slim.min.js"></script>
</body>
</html>
