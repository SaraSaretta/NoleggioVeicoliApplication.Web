using NoleggioVeicoli.WebApplication.Properties;
using NoleggioVeicoloApplication.Business.Managers;
using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static NoleggioVeicoli.WebApplication.Controls.VeicoloControl;

namespace NoleggioVeicoli.WebApplication
{
    public partial class RicercaVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VeicoloManager veicoloManager = new VeicoloManager(Settings.Default.Safo2022);

            if (!this.IsPostBack)
            {

                // this.BindGrid();


                //List<TipoAlimentazioneModel> tipoAlimentazioneList = veicoloManager.GetTipoAlimentazione();


                //ddlAlimentazione.DataSource = tipoAlimentazioneList;
                //ddlAlimentazione.DataTextField = "Alimentazione";
                //ddlAlimentazione.DataValueField = "Id";
                //ddlAlimentazione.DataBind();
                //ddlAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

                List<MarcaModel> marcaList = veicoloManager.GetMarcaList();

                ddlMarca.DataSource = marcaList;
                ddlMarca.DataTextField = "Marca";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
            }
            
        }
        //private void BindGrid()
        //{
        //    using (SqlConnection con = new SqlConnection("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;Persist Security Info=True;User ID=utente;Password=Safo2022!"))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM SAVeicoli LEFT JOIN SAMarche ON SAVeicoli.IdMarca=SAMarche.Id"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    sda.Fill(dt);
        //                    gvVeicolo.DataSource = dt;
        //                    gvVeicolo.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}
        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            var ricercaVeicoloModel = new RicercaVeicoloModel();
            
            ricercaVeicoloModel.Modello = txtModello.Text;
            ricercaVeicoloModel.Targa = txtTarga.Text;
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataImmatricolazione.Text, out dateTimeResult);
            if (okParse)
            {
                ricercaVeicoloModel.DataImmatricolazione = dateTimeResult;
            }
            //ricercaVeicoloModel.StatoNoleggio = ddlStatoNoleggio.SelectedValue;
            ricercaVeicoloModel.IdMarca = int.Parse(ddlMarca.SelectedValue);
            
            var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
            var listVeicoloModel = veicoloManager.RicercaVeicolo(ricercaVeicoloModel);
            //metto i dati nella session in modo da poterli recuperare in altra parte
            Session["listaVeicoloView"] = listVeicoloModel;
            gvVeicolo.DataSource = listVeicoloModel;
            gvVeicolo.DataBind();

        }

        //protected void gvVeicolo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    
        //}
        protected void btnDataDA_Click(object sender, EventArgs e)
        {

            if (dataImmatricolazione.Visible == false)
            {
                dataImmatricolazione.Visible = true;
            }
            // Clear the current text.
            txtDataImmatricolazione.Text = "";

            // Iterate through the SelectedDates collection and display the
            // dates selected in the Calendar control.
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {
                txtDataImmatricolazione.Text += day.Date.ToShortDateString();
            }

        }
        protected void btnDataA_Click(object sender, EventArgs e)
        {

            if (dataImmatricolazione.Visible == false)
            {
                dataImmatricolazione.Visible = true;
            }
            // Clear the current text.
            txtDataImmatricolazione2.Text = "";
            // Iterate through the SelectedDates collection and display the
            // dates selected in the Calendar control.
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {
                txtDataImmatricolazione2.Text += day.Date.ToShortDateString();
            }

        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            // { Response.Redirect("RicercaVeicolo.aspx",true); }
            ddlMarca.SelectedIndex = 0;
            txtModello.Text = string.Empty;
            txtTarga.Text = string.Empty;
            txtDataImmatricolazione.Text = string.Empty;
            txtDataImmatricolazione2.Text = string.Empty;
        }

        protected void btnDettaglio_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var row = (GridViewRow)btn.Parent.Parent;
            var id = int.Parse(row.Cells[0].Text);
            Response.Redirect("DettaglioVeicolo.aspx?Id=" + id);

        }

        //protected void gvVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var idVeicolo = gvVeicolo.SelectedDataKey["Id"].ToString();
        //    Session["Id"] = idVeicolo;
        //    Response.Redirect("DettaglioVeicolo.aspx");
        //}

        //protected void gvVeicolo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvVeicolo.PageIndex = e.NewPageIndex;
        //    this.BindGrid();
        //}

        protected void veicoloControl_VeicoloModelUpdated(object sender, EventArgsPersonalizzato e)
        {
            if (e.Messaggio != null)
            {
                // infoControl.SetMessage(Web.Controls.InfoControl.TipoMessaggio.Success, e.Messaggio);

            }
            if (e.IdVeicoloaModificata.HasValue)
            {
                //personaControl.SetPersona(e.IdPersonaModificata,)

            }


        }
    }
}