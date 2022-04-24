<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VeicoloControl.ascx.cs" Inherits="NoleggioVeicoli.WebApplication.Controls.VeicoloControl" %>

<div class="panel panel-default">
    <div class="panel-heading" style="background-color: #4775d1">
        <h3 class="panel-title">Dettaglio Veicolo</h3>
    </div>
    <div class="panel-body" style="background-color: #e6f0ff">
        <div class="row col-md-6">
            <div class="form-group">
                <label for="ddlMarca">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" ReadOnly="false">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass="form-control" ReadOnly="false">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control" ReadOnly="false">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDataImmatricolazione">Data Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass="form-control" ReadOnly="false">
                </asp:TextBox>
            </div>

        </div>
        <div class="row col-md-6">
            <div class="form-group">
                <label for="ddlAlimentazione">Alimentazione</label>
                <asp:DropDownList runat="server" ID="ddlAlimentazione" CssClass="form-control" ReadOnly="false">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtStatoNoleggio">StatoNoleggio</label>
                <asp:TextBox runat="server" ID="txtStatoNoleggio" CssClass="form-control" ReadOnly="true">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" ReadOnly="false">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCliente">Nominativo Cliente</label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" ReadOnly="false">
                </asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnModifica" Text="Salva Modifica" CssClass="btn btn-default" OnClick="btnModifica_Click" />
            <asp:Button runat="server" ID="btnDelete" Text="Elimina Veicolo" CssClass="btn btn-default" OnClick="btnDelete_Click" />
            <asp:Button runat="server" ID="btnGestisciNoleggio" Text="Gestisci Noleggio" CssClass="btn btn-default" OnClick="btnGestisciNoleggio_Click" />
        </div>
    </div>
</div>
