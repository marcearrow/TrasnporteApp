<%@ Page Title="" Language="C#" MasterPageFile="~/MasterConductor.master" AutoEventWireup="true" CodeFile="conductor_index.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPageConductor" runat="Server">

    <div class="container">
        <div>
            <br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br />
            <br />
        </div>
        <div>
          <asp:Literal ID="literal2" runat="server"><h4>Rutas por realizar</h4> </asp:Literal>  
        </div>

        <asp:GridView ID="listadoPasajes" CssClass="table table-striped table-bordered table-hover table-info" runat="Server">
        </asp:GridView>
    </div>
</asp:Content>


