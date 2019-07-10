<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="admin_vehiculos.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPage" Runat="Server">
    <br />
    <br />
    <div class="row justify-content-center ">
        <div class="col-sm-6 align-content-center">
            <div class="card">
                <div class="card-body">

                    <h5 class="card-title text-center">Agregar Vehículo</h5>

                    <div class="form-group">
                        <label for="nombreInput">Nombre: </label>
                        <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="ingrese el nombre" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="modeloInput">Modelo: </label>
                        <asp:TextBox ID="modeloInput" CssClass="form-control" placeholder="ingrese el modelo" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="capacidadInput">Capacidad: </label>
                        <asp:TextBox ID="capacidadInput" CssClass="form-control" placeholder="ingrese la capacidad" runat="server"></asp:TextBox>
                    </div>
                    <br />
                     <asp:RequiredFieldValidator ID="rfCapacidad" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar la cantidad de asientos disponibles"
                                ControlToValidate="capacidadInput"  EnableClientScript="False">

                     </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <div class="form-group">
                        <label for="patenteInput">Patente: </label>
                        <asp:TextBox ID="patenteInput" CssClass="form-control" placeholder="ingrese la patente" runat="server"></asp:TextBox>
                    </div>
                    <br />
                     <asp:RequiredFieldValidator ID="rfPatente" CssClass="alert alert-warning" runat="server"
                                ErrorMessage="Debe ingresar una patente"
                                ControlToValidate="patenteInput"  EnableClientScript="False">

                     </asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <div class="form-group">
                        <label for="ddConductores">Asignar Conductor: </label>
                        <asp:DropDownList ID="ddConductores" runat="server" CssClass="dropdown-item-text" AutoPostBack="True" OnSelectedIndexChanged="ddConductores_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <asp:Literal ID="LtMensaje" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="cmdAddVehiculo" CssClass="btn btn-primary " runat="server" Text="Agregar Vehiculo" OnClick="cmdAddVehiculo_Click" />


                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <h3 class="col-12 py-4 text-center">Lista de vehiculos</h3>
            <div class="col-12 py-3">
                <div class="row  py-3">
                    <div class="col-10">
                    <asp:TextBox ID="BuscarInput" CssClass="form-control" placeholder="Buscar por patente" runat="server"></asp:TextBox>
                        </div>
                    <div class="col-2">
                    <asp:Button ID="cmdBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="cmdBuscar_Click" />
                        </div>
                </div>
                <asp:Button ID="btnEliminar" CssClass="btn btn-primary btn-light"  runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

                <asp:GridView ID="listadoVehiculos" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="GridViewVehiculos_OnRowCommand" runat="Server">
                    <Columns>
                        <asp:BoundField  DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                        <asp:BoundField DataField="Patente" HeaderText="Patente" />
                        <asp:BoundField DataField="Conductor" HeaderText="Conductor" />
                    
                    </Columns>
                </asp:GridView>
                <asp:Literal ID="ltModificar" runat="Server"></asp:Literal>
                </div>
            </div>
        </div>

    
</asp:Content>

