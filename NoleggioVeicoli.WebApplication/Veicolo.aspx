<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Veicolo.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.Veicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc" TagName="Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <uc:Info runat="server" ID="infoControl"/>
   
    <asp:GridView runat="server" ID="gvVeicolo" CssClass="table table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="False" meta:resourcekey="gvDocumentiResource1" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="Marca" HeaderText="Marca">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText="Modello" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Targa" HeaderText="Targa">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DataImmatricolazione" HeaderText="DataImmatricolazione" DataFormatString ="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TipoAmlimentazione" HeaderText="TipoAlimentazione" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
