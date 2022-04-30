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

            if (!IsPostBack)
            {
                VeicoloManager veicoloManager = new VeicoloManager(Settings.Default.Safo2022);

                List<TipoAlimentazioneModel> tipoAlimentazioneList = veicoloManager.GetTipoAlimentazione();
                ddlTipoAlimentazione.DataSource = tipoAlimentazioneList;
                ddlTipoAlimentazione.DataTextField = "Alimentazione";
                ddlTipoAlimentazione.DataValueField = "Id";
                ddlTipoAlimentazione.DataBind();
                ddlTipoAlimentazione.Items.Insert(0, new ListItem("Seleziona Tipo Alimentazione", "-1"));

                List<MarcaModel> marcaList = SingletonManager.Instance.ListMarche;
                ddlMarca.DataSource = marcaList;
                ddlMarca.DataTextField = "Marca";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleziona Marca", "-1"));
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
            var okParse = DateTime.TryParse(txtDataImmatricolazioneInizio.Text, out dateTimeResult);
            if (okParse)
            {
                ricercaVeicoloModel.DataImmatricolazioneInizio = dateTimeResult;
            }
            DateTime dateTimeResult2;
            var okParse2 = DateTime.TryParse(txtDataImmatricolazioneFine.Text, out dateTimeResult2);
            if (okParse2)
            {
                ricercaVeicoloModel.DataImmatricolazioneFine = dateTimeResult2;
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
            if (dataImmatricolazioneInizio.Visible == false)
            {
                dataImmatricolazioneInizio.Visible = true;
            }
            txtDataImmatricolazioneInizio.Text = "";
            foreach (DateTime day in dataImmatricolazioneInizio.SelectedDates)
            {
                txtDataImmatricolazioneInizio.Text += day.Date.ToString("dd/MM/yyyy");
            }
        }
        protected void btnDataA_Click(object sender, EventArgs e)
        {
            if (dataImmatricolazioneFine.Visible == false)
            {
                dataImmatricolazioneFine.Visible = true;
            }
            txtDataImmatricolazioneFine.Text = "";
            foreach (DateTime day in dataImmatricolazioneFine.SelectedDates)
            {
                txtDataImmatricolazioneFine.Text += day.Date.ToString("dd/MM/yyyy");
            }
        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ddlMarca.SelectedIndex = 0;
            txtModello.Text = string.Empty;
            txtTarga.Text = string.Empty;
            ddlTipoAlimentazione.SelectedIndex = 0;
            ddlStatoNoleggio.SelectedIndex = 0;
            txtDataImmatricolazioneInizio.Text = string.Empty;
            txtDataImmatricolazioneFine.Text = string.Empty;
        }
        protected void dataImmatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            txtDataImmatricolazioneInizio.Text = "";
            // Scorri la raccolta SelectedDates e visualizza il file
            // date selezionate nel controllo Calendar.
            foreach (DateTime day in dataImmatricolazioneInizio.SelectedDates)
            {
                txtDataImmatricolazioneInizio.Text += day.Date.ToString("dd/MM/yyyy");
            }
        }
        protected void dataImmatricolazione2_SelectionChanged(object sender, EventArgs e)
        {
            txtDataImmatricolazioneFine.Text = "";
            foreach (DateTime day in dataImmatricolazioneFine.SelectedDates)
            {
                txtDataImmatricolazioneFine.Text += day.Date.ToString("dd/MM/yyyy");
            }
        }
        protected void gvVeicolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var Id = Convert.ToInt32(gvVeicolo.DataKeys[index].Value.ToString());
            Session["Id"] = Id;
            Response.Redirect("DettaglioVeicolo.aspx");
        }
    }
}