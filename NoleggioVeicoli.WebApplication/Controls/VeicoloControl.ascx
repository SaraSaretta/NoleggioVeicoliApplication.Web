<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VeicoloControl.ascx.cs" Inherits="NoleggioVeicoli.WebApplication.Controls.VeicoloControl" %>

 <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Dettaglio Veicolo</h3>
        </div>
        <div class="panel-body">
        <div class="form-group">
                <label for="txtMarca">Marca</label>
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" >
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDataImmatricolazione">Data Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtAlimentazione">Alimentazione</label>
                <asp:TextBox runat="server" ID="txtAlimentazione" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtStatoNoleggio">StatoNoleggio</label>
                <asp:TextBox runat="server" ID="txtStatoNoleggio" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass ="form-control">
                </asp:TextBox>
            </div>
             <asp:Button runat="server" ID="btnModifica" Text="Salva Modifica" CssClass="btn btn-default" OnClick="btnModifica_Click"  />
             <asp:Button runat="server" ID="btnDelete" Text="Elimina Veicolo" CssClass="btn btn-default" OnClick="btnDelete_Click" />
            </div>
</div>