<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="panel panel-default">
        <div class="container-fluid">
            <div class="jumbotron text-center" style="background-color: #4775d1">
                <h1 style="font-weight: bold">Gestione Noleggio Veicoli</h1>
                <p>Mobilità urbana,facile,veloce ed ecologica!</p>
            </div>
        </div>
        <div class="panel-body" style="background-color: white">
            <div class="form-group">
                <div class="text-center">
                    <img src="rent3.jpg" class="img-rounded" style="width: 1125px; height: 400px" alt="NoleggioVeicolo">
                </div>
                <div class="col-md-6">
                    <h3>Inserisci Veicolo</h3>
                    <p>Tramite tasto inferiore potresti inserire nuovo veicolo </p>
                    <asp:Button runat="server" ID="btnInserisci" Text="Inserisci veicolo" CssClass="btn btn-primary" OnClick="btnInserisci_Click" />
                </div>
                <div class="col-md-6">
                    <h3>Ricerca Veicolo</h3>
                    <p>Tramite tasto inferiore potresti cercare il veicolo desiderato </p>
                    <asp:Button runat="server" ID="btnRicerca" Text="Ricerca veicolo" CssClass="btn btn-primary" OnClick="btnRicerca_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
