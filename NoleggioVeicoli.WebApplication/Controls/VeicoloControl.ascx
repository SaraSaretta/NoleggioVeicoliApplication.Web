<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VeicoloControl.ascx.cs" Inherits="NoleggioVeicoli.WebApplication.Controls.VeicoloControl" %>

<div class="panel panel-default">
    <div class="panel-heading" style="background-color: #4775d1">
        <h3 class="panel-title">Dettaglio Veicolo</h3>
    </div>
    <div class="panel-body" style="background-color: #e6f0ff">
        <div class="row col-md-6">
            <div class="form-group">
                <label for="ddlMarca">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" ReadOnly="false" BackColor="White">
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
            <div class="form-group ">
                <label for="txtDataImmatricolazione">Data Di Immatricolazione</label>
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
                <asp:Calendar ID="dataImmatricolazione" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" BorderColor="Gray" OnSelectionChanged="dataImmatricolazione_SelectionChanged"
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

                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass="form-control">
                </asp:TextBox>
            </div>

        </div>
        <div class="row col-md-6">
            <div class="form-group">
                <label for="ddlAlimentazione">Alimentazione</label>
                <asp:DropDownList runat="server" ID="ddlAlimentazione" CssClass="form-control" ReadOnly="false" BackColor="White">
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
            <asp:Panel ID="NomeCliente" runat="server">
                <div class="form-group">
                    <label for="txtCliente">Nominativo Cliente</label>
                    <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" ReadOnly="true">
                    </asp:TextBox>
                </div>
            </asp:Panel>

            <asp:Button runat="server" ID="btnModifica" Text="Salva Modifica" CssClass="btn btn-default" OnClick="btnModifica_Click" />
            <asp:Button runat="server" ID="btnDelete" Text="Elimina Veicolo" CssClass="btn btn-default" OnClick="btnDelete_Click" />
            <asp:Button runat="server" ID="btnGestisciNoleggio" Text="Gestisci Noleggio" CssClass="btn btn-default" OnClick="btnGestisciNoleggio_Click" />
        </div>
    </div>
</div>
