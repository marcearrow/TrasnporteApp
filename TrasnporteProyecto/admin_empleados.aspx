<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="admin_empleados.aspx.cs" Inherits="_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPage" runat="Server">
    <br />
    <br />
    <div class="row justify-content-center ">
        <div class="col-sm-6 align-content-center">
            <div class="card">
                <div class="card-body">

                    <h5 class="card-title text-center">Agregar Empleado</h5>

                    <div class="form-group">
                         
                        <label for="rutInput">Rut: </label>     
                        <asp:TextBox ID="rutInput" CssClass="form-control" placeholder="ingrese el rut" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfRut" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar un rut"
                                ControlToValidate="rutInput" EnableClientScript="False">
                             </asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        
                        <label for="nombreInput">Nombre: </label>
                        
                        <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="ingrese el nombre" runat="server"></asp:TextBox>

                         <asp:RequiredFieldValidator ID="rfnombre" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar un nombre"
                                ControlToValidate="nombreInput" EnableClientScript="False">
                             </asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label for="apellidopInput">Apellido Paterno: </label>
                        <asp:TextBox ID="apellidopInput" CssClass="form-control" placeholder="ingrese el apellido paterno" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="nombreInput">Apellido Materno: </label>
                        <asp:TextBox ID="apellidomInput" CssClass="form-control" placeholder="ingrese el apellido materno" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="telefonoInput">Telefono: </label>
                        <asp:TextBox ID="telefonoInput" CssClass="form-control" placeholder="ingrese el telefono" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="emailInput">Email: </label>
                        <asp:TextBox ID="emailInput" CssClass="form-control" placeholder="ingrese el email" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRut" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar un correo valido"
                                ControlToValidate="emailInput" EnableClientScript="False"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="direccionInput">Direccion: </label>
                        <asp:TextBox ID="direccionInput" CssClass="form-control" placeholder="ingrese la dirección" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="tipoTrabajadorInput">Puesto de Trabajo: </label>
                        <asp:DropDownList ID="ddRol" runat="server" CssClass="dropdown-item-text" AutoPostBack="True" OnSelectedIndexChanged="ddRol_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <asp:Literal ID="LtMensaje" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="cmdAddEmpleado" CssClass="btn btn-primary " runat="server" Text="Agregar Empleado" OnClick="cmdAddEmpleado_Click" />


                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <h3 class="col-12 py-4 text-center">Lista de empleados</h3>
            <div class="col-12 py-3">
                <div class="row  py-3">
                    <div class="col-10">
                        <asp:TextBox ID="BuscarInput" CssClass="form-control" placeholder="Buscar por Rut" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="cmdBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="cmdBuscar_Click" />
                    </div>
                </div>
                <asp:Button ID="btnEliminar" CssClass="btn btn-primary btn-light"  runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                
                <asp:GridView ID="listadoEmpleados" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="GridViewEmpleados_OnRowCommand" runat="Server">
                    <Columns>
                        <asp:BoundField ItemStyle-CssClass="" DataField="Rut" HeaderText="Rut" />
                        <asp:BoundField DataField="Empleado" HeaderText="Nombre Empleado" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                    </Columns>
                </asp:GridView>

                <asp:Literal ID="ltModificar" runat="Server"></asp:Literal>

            </div>
        </div>
    </div>
</asp:Content>

