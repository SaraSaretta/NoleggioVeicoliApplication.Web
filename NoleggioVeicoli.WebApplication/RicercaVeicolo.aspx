<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaVeicolo.aspx.cs" Inherits="NoleggioVeicoli.WebApplication.RicercaVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagName="Info" TagPrefix="uc" %>
<%@ Register Src="~/Controls/VeicoloControl.ascx" TagName="VeicoloControl" TagPrefix="vc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <uc:Info runat="server" ID="infoControl" />

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Ricerca Veicolo</h3>
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
             <div class="form-group">
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
           
            <div class="form-group">
                <p></p>
            
                <p>Da:</p>
                 <asp:Button runat="server" ID="btnDataDA" Text="..." CssClass="btn btn-Default" OnClick="btnDataDA_Click" />
                     <script language="C#" runat="server" >
                        void DayRender(Object source, DayRenderEventArgs e)
                        {

                            // Change the background color of the days in the month
                            // to yellow.
                            if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
                                e.Cell.BackColor=System.Drawing.Color.White;

                            //// Add custom text to cell in the Calendar control.
                            //if (e.Day.Date.Day == 18)
                            //   e.Cell.Controls.Add(new LiteralControl());

                        }
                     </script>
   
             <asp:Calendar id="dataImmatricolazione" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" bordercolor="Gray"
                           OnDayRender="DayRender" Visible="false"
                           runat="server">
                  <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                  <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
                  <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                  <SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
                  <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="1px" ForeColor="#333399" bordercolor="gray" BackColor="white"></TitleStyle>
                  <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                  <WeekendDayStyle BackColor="lightyellow">
                  </WeekendDayStyle>
            </asp:Calendar>
            <asp:Label id="dataLabel" runat="server" />
                </div>
             <div class="form-group">
                <label for="txtDataImmatricolazione2">Data Di Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazione2" CssClass ="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                  <p>A:</p><asp:Button  runat="server" ID="btnDataA" Text="..." CssClass="btn btn-Default" OnClick="btnDataA_Click" />

                    <script language="C#" runat="server" >
                         void DayRender2(Object source, DayRenderEventArgs e) 
                         {

                             // Change the background color of the days in the month
                             // to yellow.
                             if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
                                e.Cell.BackColor=System.Drawing.Color.White;

                         }
                     </script>
      <asp:Calendar id="dataImmatricolazione2" BorderWidth="1px" NextPrevFormat="FullMonth" Width="280px" Height="190px" bordercolor="Gray"
                    OnDayRender="DayRender2" Visible="false"
                    runat="server">
          <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
          <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
                <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                <SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
                <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="1px" ForeColor="#333399" bordercolor="gray" BackColor="white"></TitleStyle>
                <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
         <WeekendDayStyle BackColor="lightyellow">
         </WeekendDayStyle>
      </asp:Calendar>
            <asp:Label id="dataLabal" runat="server" />
            </div>
            <div class="form-group ">
               <label for="ddlStatoNoleggio">Stato Noleggio</label>
               <asp:DropDownList ID="ddlStatoNoleggio" runat="server" CssClass="form-control" >
                   <asp:ListItem Selected="True" Value="Si"> Si </asp:ListItem>
                  <asp:ListItem Value="No"> No </asp:ListItem>
               </asp:DropDownList>
            </div>
                
            <asp:Button runat="server" ID="btnRicerca" Text="Ricerca" CssClass="btn btn-secondary" OnClick="btnRicerca_Click" Font="bold"/>
            <asp:Button ID="BtnClear" runat="server" Text="Risetta" CssClass="btn btn-secondary" OnClick="BtnClear_Click"/>  
    
         </div>    
    </div>
    </div>

    <asp:GridView runat="server" ID="gvVeicolo" CssClass="table table table-bordered table-hover table-striped no-margin" 
        BorderStyle="None" AutoGenerateColumns="False" meta:resourcekey="gvDocumentiResource1" AutoGenerateSelectButton="false" DataKeyNames="Id">
        <Columns>
            <asp:BoundField ItemStyle-Width="150px" DataField="Id" HeaderText="Id" visible="false">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="Marca" HeaderText="Marca" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField  ItemStyle-Width="150px" DataField="Modello" HeaderText="Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="Targa" HeaderText="Targa" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="150px" DataField="DataImmatricolazione" HeaderText="DataImmatricolazione">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField ItemStyle-Width="150px" DataField="StatoNoleggio" HeaderText="StatoNoleggio">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDettaglio" runat="server" Text="Dettaglio" OnClick="btnDettaglio_Click" DataField="Dettaglio" HeaderText="Dettaglio" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
      <%-- <vc:VeicoloControl runat="server" ID="veicoloControl" OnVeicoloModelUpdated="veicoloControl_VeicoloModelUpdated" />--%>
</asp:Content>
