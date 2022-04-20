<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioVeicolo.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.DettaglioVeicolo1" %>


<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc" TagName="InfoControl" %>
<%@ Register Src="~/Controls/VeicoloControl.ascx" TagPrefix="vc" TagName="VeicoloControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

    <uc:InfoControl runat="server" ID="infoControl" />
    <div class="panel panel-default">
        <div class="panel-heading">
 <asp:Button ID="btnIndietro" runat="server" Text="Indietro" OnClick="btnIndietro_Click" DataKeyNames="Id" />
 <asp:Button ID="btnAvanti" runat="server" Text="Avanti" OnClick="btnAvanti_Click" DataKeyNames="Id" />
        </div>
     </div>
     <vc:VeicoloControl runat="server" ID="veicoloControl" OnVeicoloModelUpdated="veicoloControl_VeicoloModelUpdated1"/>
        
</asp:Content>
