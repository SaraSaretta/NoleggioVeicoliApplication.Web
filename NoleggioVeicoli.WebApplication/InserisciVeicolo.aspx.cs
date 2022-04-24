using NoleggioVeicoli.WebApplication.Controls;
using NoleggioVeicoloApplication.Business.Managers;
using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static NoleggioVeicoli.WebApplication.Controls.VeicoloControl;

namespace NoleggioVeicoli.WebApplication
{
    public partial class InserisciVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                VeicoloManager veicoloManager = new VeicoloManager(Properties.Settings.Default.Safo2022);

                List<TipoAlimentazioneModel> tipoAlimentazioneList = veicoloManager.GetTipoAlimentazione();

                ddlAlimentazione.DataSource = tipoAlimentazioneList;
                ddlAlimentazione.DataValueField = "Id";
                ddlAlimentazione.DataTextField = "Alimentazione";
                ddlAlimentazione.DataBind();
                ddlAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

                List<MarcaModel> marcaList = SingletonManager.Instance.ListMarche;

                ddlMarca.DataSource = marcaList;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Marca";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
            }
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            if (!IsFormValido())
            {
                infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Danger, "Il form non è valido, Inserisci tutti record,per favore!");
                return;
            }
            else
            {
                VeicoloManager veicoloManager = new VeicoloManager(Properties.Settings.Default.Safo2022);
                var veicoloModel = new VeicoloModel();

                veicoloModel.IdMarca = int.Parse(ddlMarca.SelectedValue);
                veicoloModel.Modello = txtModello.Text;
                veicoloModel.Targa = txtTarga.Text;
                veicoloModel.IdTipoAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);
                DateTime dateTimeResult;
                var okParse = DateTime.TryParse(txtDataImmatricolazione.Text, out dateTimeResult);
                if (okParse)
                {
                    veicoloModel.DataImmatricolazione = dateTimeResult;
                }
                veicoloModel.StatoNoleggio = ddlStatoNoleggio.SelectedValue;
                veicoloModel.Note = txtNote.Text;

                bool isVeicoloInserita = veicoloManager.InsertVeicolo(veicoloModel);
                infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Success, "Il veicolo è stato inserito correttamente");

            }
        }
        private bool IsFormValido()
        {
            if (string.IsNullOrWhiteSpace(ddlMarca.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtModello.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTarga.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDataImmatricolazione.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(ddlAlimentazione.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(ddlStatoNoleggio.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                return false;
            }
            return true;
        }
        protected void dataImmatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            txtDataImmatricolazione.Text = "";
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {
                txtDataImmatricolazione.Text += day.Date.ToShortDateString();
            }
        }
        protected void btnData_Click(object sender, EventArgs e)
        {
            if (dataImmatricolazione.Visible == false)
            {
                dataImmatricolazione.Visible = true;
            }
            var veicoloModel = new VeicoloModel();
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataImmatricolazione.Text, out dateTimeResult);
            if (okParse)
            {
                veicoloModel.DataImmatricolazione = dateTimeResult;
            }
        }
    }
}