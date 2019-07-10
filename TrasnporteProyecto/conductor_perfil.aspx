<%@ Page Title="" Language="C#" MasterPageFile="~/MasterConductor.master" AutoEventWireup="true" CodeFile="conductor_perfil.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPageConductor" runat="Server">
    <br />
    <br />
    <div class="row justify-content-center ">
        <div class="col-sm-6 align-content-center">
            <div class="card">
                <div class="card-body">

                    <h5 class="card-title text-center">Mi Perfil</h5>

                    <div class="form-group">

                        <label for="rutInput">Rut: </label>
                        <asp:TextBox ID="rutInput"  CssClass="form-control disabled" placeholder="ingrese el rut" runat="server"  Enabled="False"></asp:TextBox>
                    </div>

                    <div class="form-group">

                        <label for="nombreInput">Nombre: </label>
                        <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="ingrese el nombre" runat="server" Enabled="False"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="apellidopInput">Apellido Paterno: </label>
                        <asp:TextBox ID="apellidopInput" CssClass="form-control disabled" placeholder="ingrese el apellido paterno" runat="server" Enabled="False"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="apellidomInput">Apellido Materno: </label>
                        <asp:TextBox ID="apellidomInput" CssClass="form-control disabled" placeholder="ingrese el apellido materno" runat="server" Enabled="False"></asp:TextBox>
                    </div>

                    <div class="form-group">
                            <label for="contraseniaInput">Contraseña: </label>
                            <asp:TextBox ID="contraseniaInput" CssClass="form-control" placeholder="ingrese su contraseña" runat="server"></asp:TextBox>
                           
                        </div>

                    <div class="form-group">
                        <label for="telefonoInput">Telefono: </label>
                        <asp:TextBox ID="telefonoInput" CssClass="form-control " placeholder="ingrese el telefono" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="emailInput">Email: </label>
                        <asp:TextBox ID="emailInput" CssClass="form-control" placeholder="ingrese el email" runat="server" TextMode="Email"></asp:TextBox>
                    
                    </div>
                    <div class="form-group">
                        <label for="direccionInput">Direccion: </label>
                        <asp:TextBox ID="direccionInput" CssClass="form-control" placeholder="ingrese la dirección" runat="server"></asp:TextBox>
                    </div>


                    <asp:Literal ID="LtMensaje" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="cmdModEmpleado" CssClass="btn btn-primary " runat="server" Text="Modificar Datos" OnClick="cmdModEmpleado_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>

