<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioVeicolo.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.DettaglioVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc" TagName="InfoControl" %>
<%@ Register Src="~/Controls/VeicoloControl.ascx" TagPrefix="vc1" TagName="VeicoloControl" %>

<asp:Content ID="gvVeicolo" ContentPlaceHolderID="MainContent" runat="server">

    <uc:InfoControl runat="server" ID="infoControl" />

    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:Button ID="btnIndietro" runat="server" Text="Indietro" OnClick="btnIndietro_Click" />
            <asp:Button ID="btnAvanti" runat="server" Text="Avanti" OnClick="btnAvant_Click" />
        </div>
    </div>

    <vc1:VeicoloControl runat="server" ID="veicoloControl" OnVeicoloModelUpdated="veicoloControl_VeicoloModelUpdated" />

</asp:Content>
