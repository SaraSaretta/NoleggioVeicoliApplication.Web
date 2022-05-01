<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuovoCliente.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.NuovaCliente" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Info runat="server" ID="infoControl" />

    <div class="panel panel-default">
        <div class="panel-heading" style="background-color: #4775d1">
            <h3 class="panel-title" style="font-weight: bold">Nuovo Cliente</h3>
        </div>
        <div class="panel-body" style="background-color: #e6f0ff">
            <div class="row col-md-6">
                <div class="form-group ">
                    <label for="txtCodiceFiscale">CodiceFiscale</label>
                    <asp:TextBox runat="server" ID="txtCodiceFiscale" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtDataNascita">Data Di Nascita</label>
                    <br />
                    <asp:Button runat="server" ID="btnData" Text="..." CssClass="btn btn-default" OnClick="btnData_Click" />
                    <script language="C#" runat="server">
                        void DayRender(Object source, DayRenderEventArgs e)
                        {
                            //Colore di background 
                            if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
                                e.Cell.BackColor = System.Drawing.Color.White;
                            // Aggiungere la data inserita a Calendar control.
                            if (e.Day.Date.Day == 18)
                                e.Cell.Controls.Add(new LiteralControl());
                        }
                    </script>
                    <asp:Calendar ID="dataNascita" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" BorderColor="Gray" OnSelectionChanged="dataNascita_SelectionChanged"
                        OnDayRender="DayRender"
                        runat="server" Visible="false">
                        <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                        <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
                        <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                        <SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
                        <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="1px" ForeColor="#333399" BorderColor="gray" BackColor="white"></TitleStyle>
                        <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                        <WeekendDayStyle BackColor="lightyellow"></WeekendDayStyle>
                    </asp:Calendar>
                    <asp:Label ID="dataLabel" runat="server" Font-Bold="true" />
                    <asp:TextBox runat="server" ID="txtDataNascita" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtEmail">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtTelefono">Telefono</label>
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtNumeroPatente">Numero Patente</label>
                    <asp:TextBox runat="server" ID="txtNumeroPatente" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>
            <div class="form-group ">
                <label for="txtCliente"></label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" Visible="false">
                </asp:TextBox>
            </div>
            <div class="row col-md-6">
                <div class="form-group ">
                    <label for="txtNazione">Nazione</label>
                    <asp:TextBox runat="server" ID="txtNazione" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtProvincia">Provincia</label>
                    <asp:TextBox runat="server" ID="txtProvincia" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtCitta">Città</label>
                    <asp:TextBox runat="server" ID="txtCitta" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="txtIndirizzo">Indirizzo</label>
                    <asp:TextBox runat="server" ID="txtIndirizzo" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>
            <asp:Button runat="server" ID="btnSalva" Text="Salva Dati" CssClass="btn btn-default" OnClick="btnSalva_Click" />
        </div>
    </div>
</asp:Content>
