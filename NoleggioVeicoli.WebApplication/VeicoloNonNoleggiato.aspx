<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VeicoloNonNoleggiato.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.VeicoloNonNoleggiato" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:panel class="panel panel-default" id="pnlNonNoleggiato" runat="server">
        <asp:panel class="panel-heading" runat="server" ID="pnlHeadNonNoleggiato">
            <h3 class="panel-title">Veicolo Non Noleggiato</h3>
        </asp:panel>
        <div class="panel-body">
            <div class="form-group ">
               <label for="txtMarca">Marca</label>
               <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" ReadOnly="true">
               </asp:TextBox>
            </div>
            <div class="form-group ">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass ="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
             <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass ="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
            <div class="row col-md-6">
                <div class="form-group">
                <label for="txtCliente">Cliente</label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnNoleggiaVeicolo" Text="Noleggia Veicolo" CssClass="btn btn-secondary" OnClick="btnNoleggiaVeicolo_Click"/>

                </div>
                </div>
    

    </asp:panel>



</asp:Content>
