<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="admin_sucursales.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPage" runat="Server">
    <br />
    <br />
    <div class="row justify-content-center ">
        <div class="col-sm-6 align-content-center">
            <div class="card">
                <div class="card-body">

                    <h5 class="card-title text-center">Agregar Sucursal</h5>

                    <div class="form-group">
                        <label for="nombreInput">Nombre: </label>
                        <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="ingrese el nombre" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="descripcionInput">Descripción: </label>
                        <asp:TextBox ID="descripcionInput" CssClass="form-control" placeholder="ingrese la descripción" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="direccionInput">Dirección: </label>
                        <asp:TextBox ID="direccionInput" CssClass="form-control" placeholder="ingrese la direccion" runat="server"></asp:TextBox>
                    </div>
                    <asp:Literal ID="LtMensaje" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="cmdAddSucursal" CssClass="btn btn-primary " runat="server" Text="Agregar Sucursal" OnClick="cmdAddSucursal_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <h3 class="col-12 py-4 text-center">Lista de Sucursales</h3>
            <div class="col-12 py-3">
                 <div class="row  py-3">
                    <div class="col-10">
                    <asp:TextBox ID="BuscarInput" CssClass="form-control" placeholder="Buscar por nombre" runat="server"></asp:TextBox>
                        </div>
                    <div class="col-2">
                    <asp:Button ID="cmdBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="cmdBuscar_Click" />
                        </div>
                </div>
                <asp:Button ID="btnEliminar" CssClass="btn btn-primary btn-light"  runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:GridView ID="listadoSucursales" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="GridViewSucursales_OnRowCommand" runat="Server">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />

                        
                    </Columns>
                </asp:GridView>
                 <asp:Literal ID="ltModificar" runat="Server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>

