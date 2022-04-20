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
                <label for="txtDataImmatricolazione">Data Di Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtAlimentazione">Tipo Alimentazione</label>
                <asp:TextBox runat="server" ID="txtAlimentazione" CssClass ="form-control">
                </asp:TextBox>
            </div>
           
             <asp:Button runat="server" ID="btnModifica" Text="Modifica" CssClass="btn btn-default" OnClick="btnModifica_Click1" />
             <%--<asp:Button runat="server" ID="btnAggiorna" Text="Aggiorna" CssClass="btn btn-default" OnClick="btnAggiorna_Click" />--%>

       </div>
         </div>

    
