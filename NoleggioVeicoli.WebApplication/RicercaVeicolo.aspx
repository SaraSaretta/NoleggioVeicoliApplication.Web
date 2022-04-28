<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaVeicolo.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.RicercaVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagName="Info" TagPrefix="uc" %>
<%@ Register Src="~/Controls/VeicoloControl.ascx" TagName="VeicoloControl" TagPrefix="vc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Info runat="server" ID="infoControl" />

    <div class="panel panel-default">
        <div class="panel-heading" style="background-color: #4775d1">
            <h3 class="panel-title" style="font-weight: bold">Ricerca Veicolo</h3>
        </div>
        <div class="panel-body" style="background-color: #e6f0ff">
            <div class="row col-md-6">
                <div class="form-group ">
                    <label for="ddlMarca">Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group ">
                    <label for="txtModello">Modello</label>
                    <asp:TextBox runat="server" ID="txtModello" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtTarga">Targa</label>
                    <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group ">
                    <label for="ddlTipoAlimentazione">Tipo Alimentazione</label>
                    <asp:DropDownList ID="ddlTipoAlimentazione" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group ">
                    <label for="ddlStatoNoleggio">Stato Noleggio</label>
                    <asp:DropDownList ID="ddlStatoNoleggio" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Seleziona"> Seleziona </asp:ListItem>
                        <asp:ListItem Value="Si"> Si </asp:ListItem>
                        <asp:ListItem Value="No"> No </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row col-md-6">
                <div class="form-group ">
                    <label for="txtDataImmatricolazioneInizio">Data Di Immatricolazione</label>
                    <div class="form-group">
                        <p>Da:</p>
                        <asp:Button runat="server" ID="btnDataDA" Text="..." CssClass="btn btn-default" OnClick="btnDataDA_Click" />
                        <script language="C#" runat="server">
                            void DayRender(Object source, DayRenderEventArgs e)
                            {
                                // Change the background color of the days in the month
                                // to yellow.
                                if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
                                    e.Cell.BackColor = System.Drawing.Color.White;

                                //// Add custom text to cell in the Calendar control.
                                if (e.Day.Date.Day == 18)
                                    e.Cell.Controls.Add(new LiteralControl());
                            }
                        </script>
                        <asp:Calendar ID="dataImmatricolazioneInizio" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" BorderColor="Gray"
                            OnDayRender="DayRender" Visible="false" OnSelectionChanged="dataImmatricolazione_SelectionChanged"
                            runat="server">
                            <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                            <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
                            <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                            <SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
                            <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="1px" ForeColor="#333399" BorderColor="gray" BackColor="white"></TitleStyle>
                            <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                            <WeekendDayStyle BackColor="lightyellow"></WeekendDayStyle>
                        </asp:Calendar>
                        <asp:Label ID="dataLabel" runat="server" />
                        <asp:TextBox runat="server" ID="txtDataImmatricolazioneInizio" CssClass="form-control">
                        </asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtDataImmatricolazioneFine"></label>

                    <div class="form-group">
                        <p>A:</p>
                        <asp:Button runat="server" ID="btnDataA" Text="..." CssClass="btn btn-default" OnClick="btnDataA_Click" />

                        <script language="C#" runat="server">
                            void DayRender2(Object source, DayRenderEventArgs e)
                            {
                                if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
                                    e.Cell.BackColor = System.Drawing.Color.White;
                                if (e.Day.Date.Day == 18)
                                    e.Cell.Controls.Add(new LiteralControl());
                            }
                        </script>
                        <asp:Calendar ID="dataImmatricolazioneFine" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" BorderColor="Gray"
                            OnDayRender="DayRender2" Visible="false" OnSelectionChanged="dataImmatricolazione2_SelectionChanged"
                            runat="server">
                            <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                            <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
                            <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                            <SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
                            <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="1px" ForeColor="#333399" BorderColor="gray" BackColor="white"></TitleStyle>
                            <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                            <WeekendDayStyle BackColor="lightyellow"></WeekendDayStyle>
                        </asp:Calendar>
                        <asp:Label ID="dataLabal2" runat="server" />
                        <asp:TextBox runat="server" ID="txtDataImmatricolazioneFine" CssClass="form-control">
                        </asp:TextBox>
                    </div>
                </div>
                <asp:Button runat="server" ID="btnRicerca" Text="Ricerca" CssClass="btn btn-default" OnClick="btnRicerca_Click" />
                <asp:Button ID="BtnClear" runat="server" Text="Risetta" CssClass="btn btn-default" OnClick="BtnClear_Click" />
            </div>
        </div>
    </div>
    <asp:GridView runat="server" ID="gvVeicolo" CssClass="table table table-bordered table-hover table-striped no-margin"
        BorderStyle="None" AutoGenerateColumns="False" meta:resourcekey="gvDocumentiResource1" DataKeyNames="Id" OnRowCommand="gvVeicolo_RowCommand"  AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField ItemStyle-Width="150px" DataField="Marca" HeaderText="Marca">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="Modello" HeaderText="Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="Targa" HeaderText="Targa">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="DataImmatricolazione" HeaderText="DataImmatricolazione">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="TipoAlimentazione" HeaderText="TipoAlimentazione">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="StatoNoleggio" HeaderText="StatoNoleggio">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" HeaderText="Dettaglio" Text="Dettaglio">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>

</asp:Content>
