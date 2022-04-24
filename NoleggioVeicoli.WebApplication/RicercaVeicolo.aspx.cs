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

                List<TipoAlimentazioneModel> tipoAlimentazioneList = veicoloManager.GetTipoAlimentazione();

                ddlTipoAlimentazione.DataSource = tipoAlimentazioneList;
                ddlTipoAlimentazione.DataTextField = "Alimentazione";
                ddlTipoAlimentazione.DataValueField = "Id";
                ddlTipoAlimentazione.DataBind();
                ddlTipoAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

                List<MarcaModel> marcaList = veicoloManager.GetMarcaList();

                ddlMarca.DataSource = marcaList;
                ddlMarca.DataTextField = "Marca";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
            }

        }
        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            var ricercaVeicoloModel = new RicercaVeicoloModel();

            ricercaVeicoloModel.IdMarca = int.Parse(ddlMarca.SelectedValue);
            ricercaVeicoloModel.Modello = txtModello.Text;
            ricercaVeicoloModel.Targa = txtTarga.Text;
            ricercaVeicoloModel.IdTipoAlimentazione = int.Parse(ddlTipoAlimentazione.SelectedValue);
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataImmatricolazione.Text, out dateTimeResult);
            if (okParse)
            {
                ricercaVeicoloModel.DataImmatricolazione = dateTimeResult;
            }
            ricercaVeicoloModel.StatoNoleggio = ddlStatoNoleggio.SelectedValue;
            
            var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
            var listVeicoloModel = veicoloManager.RicercaVeicolo(ricercaVeicoloModel);
            //metto i dati nella session in modo da poterli recuperare in altra parte
            Session["listaVeicoloView"] = listVeicoloModel;
            gvVeicolo.DataSource = listVeicoloModel;
            gvVeicolo.DataBind();
        }
        protected void btnDataDA_Click(object sender, EventArgs e)
        {

            if (dataImmatricolazione.Visible == false)
            {
                dataImmatricolazione.Visible = true;
            }
            txtDataImmatricolazione.Text = "";
            // Scorri la raccolta SelectedDates e visualizza il file
            // date selezionate nel controllo Calendar.
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {
                txtDataImmatricolazione.Text += day.Date.ToShortDateString();
            }
        }
        protected void btnDataA_Click(object sender, EventArgs e)
        {
            if (dataImmatricolazione2.Visible == false)
            {
                dataImmatricolazione2.Visible = true;
            }
            // Clear the current text.
            txtDataImmatricolazione2.Text = "";
            // Iterate through the SelectedDates collection and display the
            // dates selected in the Calendar control.
            foreach (DateTime day in dataImmatricolazione2.SelectedDates)
            {
                txtDataImmatricolazione2.Text += day.Date.ToShortDateString();
            }
        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ddlMarca.SelectedIndex = 0;
            txtModello.Text = string.Empty;
            txtTarga.Text = string.Empty;
            ddlStatoNoleggio.SelectedIndex = 0;
            txtDataImmatricolazione.Text = string.Empty;
            txtDataImmatricolazione2.Text = string.Empty;
        }
        protected void dataImmatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            // Cancello se già è pieno
            txtDataImmatricolazione.Text = "";

            // Scorri la raccolta SelectedDates e visualizza il file
            // date selezionate nel controllo Calendar.
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {
                txtDataImmatricolazione.Text += day.Date.ToShortDateString();
            }

        }
        protected void dataImmatricolazione2_SelectionChanged(object sender, EventArgs e)
        {
            // Cancello se già è pieno
            txtDataImmatricolazione2.Text = "";

            // Scorri la raccolta SelectedDates e visualizza il file
            // date selezionate nel controllo Calendar.
            foreach (DateTime day in dataImmatricolazione2.SelectedDates)
            {
                txtDataImmatricolazione2.Text += day.Date.ToShortDateString();
            }

        }
        protected void gvVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idVeicolo = gvVeicolo.SelectedDataKey["Id"].ToString();
            Session["id"] = idVeicolo;
            Response.Redirect("DettaglioVeicolo.aspx");
        }
        //protected void btnDettaglio_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    var row = (GridViewRow)btn.Parent.Parent;
        //    var id = int.Parse(row.Cells[0].Text);
        //    Response.Redirect("DettaglioVeicolo.aspx?Id=" + id);
        //}

    }
}