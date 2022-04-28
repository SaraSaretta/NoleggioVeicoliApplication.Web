<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VeicoloNoleggiato.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.VeicoloNoleggiato" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Info runat="server" ID="infoControl" />

    <div class="panel-heading" style="background-color: #4775d1">
        <h3 class="panel-title" style="font-weight: bold">Veicolo Noleggiato</h3>
    </div>
    <div class="panel-body" style="background-color: #e6f0ff">
        <div class="form-group ">
            <label for="txtMarca">Marca</label>
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" ReadOnly="true">
            </asp:TextBox>
        </div>
        <div class="form-group ">
            <label for="txtModello">Modello</label>
            <asp:TextBox runat="server" ID="txtModello" CssClass="form-control" ReadOnly="true">
            </asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTarga">Targa</label>
            <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control" ReadOnly="true">
            </asp:TextBox>
        </div>
        <div class="row col-md-6">
            <div class="form-group">
                <label for="txtCliente">Nominativo Cliente</label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnFineNoleggio" Text="Fine Noleggio" CssClass="btn btn-default" OnClick="btnFineNoleggio_Click" />
        </div>
    </div>

</asp:Content>
