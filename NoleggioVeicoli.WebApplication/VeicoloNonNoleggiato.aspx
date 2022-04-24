<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VeicoloNonNoleggiato.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.VeicoloNonNoleggiato" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel class="panel panel-default" ID="pnlNonNoleggiato" runat="server">
        <div class="panel-heading" style="background-color: #4775d1">
            <h3 class="panel-title" style="font-weight: bold">Veicolo Non Noleggiato</h3>
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
                    <label for="txtCliente">Cliente</label>
                    <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" ReadOnly="false">
                    </asp:TextBox>
                </div>
                <asp:Button runat="server" ID="btnNoleggiaVeicolo" Text="Noleggia Veicolo" CssClass="btn btn-default" OnClick="btnNoleggiaVeicolo_Click" />

            </div>
        </div>


    </asp:Panel>



</asp:Content>
