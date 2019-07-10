<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="admin_index.aspx.cs" Inherits="index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoNestedMasterPage" runat="Server">

    <div class="container">
        <br />
        <br />
        <h3>Conductores</h3>
        <br />
        <div>
            <asp:GridView ID="GridView1" class="table-bordered table table-hover table-info" runat="server"></asp:GridView>
        </div>

         <br />
        <br />
        <h3>Vendedores</h3>
        <br />
        <div>
            <asp:GridView ID="GridView2" class="table-bordered table table-hover table-info" runat="server"></asp:GridView>
        </div>
    </div>


</asp:Content>
