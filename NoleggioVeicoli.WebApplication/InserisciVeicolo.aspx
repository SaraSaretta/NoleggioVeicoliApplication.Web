<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciVeicolo.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.InserisciVeicolo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title" >Inserisci Veicolo</h3>
        </div>

        <div class="panel-body">
           <div class="row col-md-6">
        <div class="form-group ">
            <label for="ddlMarca">Marca</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" >
            </asp:DropDownList>
        </div>
            <div class="form-group ">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass ="form-control">
                </asp:TextBox>
            </div>
             <div class="form-group ">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass ="form-control">
                </asp:TextBox>
            </div>
               </div>
        <div class="row col-md-6">
             <div class="form-group ">
                <label for="txtDataImmatricolazione">Data Di Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnData" Text="..." CssClass="btn btn-Default" OnClick="btnData_Click" />
            <script language="C#" runat="server" >
                 void DayRender(Object source, DayRenderEventArgs e) 
                 {
                     // Change the background color of the days in the month
                     // to yellow.
                     if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
                        e.Cell.BackColor=System.Drawing.Color.White;

                     // Add custom text to cell in the Calendar control.
                     if (e.Day.Date.Day == 18)
                        e.Cell.Controls.Add(new LiteralControl());

                 }
             </script>
           
      <asp:Calendar id="dataImmatricolazione" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" bordercolor="Gray" OnSelectionChanged="dataImmatricolazione_SelectionChanged"
                    OnDayRender="DayRender"
                    runat="server" Visible="false">
          <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
          <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
<DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
<TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="1px" ForeColor="#333399" bordercolor="gray" BackColor="white"></TitleStyle>
<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
         <WeekendDayStyle BackColor="lightyellow">
         </WeekendDayStyle>
      </asp:Calendar>
            


             <%-- void Selection_Change(Object sender, EventArgs e) 
              {
                   dataLabel.Text = "The selected date is " + dataImmatricolazione.SelectedDate.ToShortDateString();
              }

   </script>
            <asp:CalendarExtender  ID="dataImmatricolazione" runat="server"   BorderWidth="1px" NextPrevFormat="FullMonth" BackColor="White" Width="280px" ForeColor="Black" Height="190px" Font-Size="9pt" Font-Names="Verdana" BorderColor="White"
                          SelectionMode="Day" 
                          ShowGridLines="True"
                          OnSelectionChanged="Calendar1_SelectionChanged">
 
            <SelectedDayStyle BackColor="lightBlue"
                              ForeColor="Red">
            </SelectedDayStyle>
      
            </asp:CalendarExtender>  --%> 
            <asp:Label id="dataLabel" runat="server" />

            <div class="form-group ">
            <label for="ddlAlimentazione">Alimentazione</label>
            <asp:DropDownList ID="ddlAlimentazione" runat="server" CssClass="form-control" >
            </asp:DropDownList>
        </div>
            <div class="form-group ">
               <label for="ddlStatoNoleggio">Stato Noleggio</label>
               <asp:DropDownList ID="ddlStatoNoleggio" runat="server" CssClass="form-control" >
                   <asp:ListItem Selected="True" Value="Si"> Si </asp:ListItem>
                  <asp:ListItem Value="No"> No </asp:ListItem>
               </asp:DropDownList>
            </div>
            <div class="form-group ">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnInserisci" Text="Inserisci" CssClass="btn btn-secondary" OnClick="btnInserisci_Click"  />
            </div>
            </div>
    </div>
</asp:Content>
