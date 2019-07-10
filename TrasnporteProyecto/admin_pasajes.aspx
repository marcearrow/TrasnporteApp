<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="admin_pasajes.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPage" runat="Server">
    <br />
    <br />
    <div class="row justify-content-center ">
        <div class="col-sm-6 align-content-center">
            <div class="card">
                <div class="card-body">

                    <h5 class="card-title text-center">Agregar Pasaje</h5>


                    <div class="form-group">
                        <label for="nombreInput">Nombre pasaje: </label>
                        <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="ingrese el nombre" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="fechaInput">Fecha: </label>
                        <asp:Calendar ID="Calendar1" CssClass="card-body alert-primary" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" SelectionMode="Day" CellPadding="4" CellSpacing="4" DayHeaderStyle-HorizontalAlign="Center"></asp:Calendar>
                        <br />
                        <asp:TextBox ID="fechaInput" CssClass="form-control" placeholder="fecha" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="precioInput">Precio pasaje: </label>
                        <asp:TextBox ID="precioInput" TextMode="Number" CssClass="form-control" placeholder="ingrese el precio" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddRuta">Ruta: </label>
                        <asp:DropDownList ID="ddRuta" runat="server" CssClass="dropdown-item-text" AutoPostBack="True" OnSelectedIndexChanged="ddRuta_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <div class="form-group">
                            <label for="ddVehiculo">Vehiculo: </label>
                            <asp:DropDownList ID="ddVehiculo" runat="server" CssClass="dropdown-item-text" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        </div>
                        <br />
                        <asp:Literal ID="LtMensaje" runat="server"></asp:Literal>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="cmdAddPasaje" CssClass="btn btn-primary " runat="server" Text="Agregar Pasaje" OnClick="cmdAddPasaje_Click" />

                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <h3 class="col-12 py-4 text-center">Lista de Pasajes</h3>
                <div class="col-12 py-3">
                    <div class="row  py-3">
                        <div class="col-10">
                            <asp:TextBox ID="BuscarInput" CssClass="form-control" placeholder="Buscar por nombre" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <asp:Button ID="cmdBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="cmdBuscar_Click" />
                        </div>
                    </div>
                    <asp:Button ID="btnEliminar" CssClass="btn btn-primary btn-light" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

                    <asp:GridView ID="listadoPasajes" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" runat="Server">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Ruta" HeaderText="Ruta" />
                            <asp:BoundField DataField="Vehiculo" HeaderText="Vehiculo" />


                        </Columns>
                    </asp:GridView>
                    <asp:Literal ID="ltModificar" runat="Server"></asp:Literal>
                </div>
            </div>
        </div>
    
    
</asp:Content>

