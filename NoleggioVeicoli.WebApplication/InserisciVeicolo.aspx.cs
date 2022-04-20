using NoleggioVeicoli.WebApplication.Controls;
using NoleggioVeicoloApplication.Business.Managers;
using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioVeicoli.WebApplication
{
    public partial class InserisciVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VeicoloManager veicoloManager = new VeicoloManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;Persist Security Info=True;User ID=utente;Password=Safo2022!");

                List<TipoAlimentazioneModel> tipoAlimentazioneList = veicoloManager.GetTipoAlimentazione();

                ddlAlimentazione.DataSource = tipoAlimentazioneList;
                ddlAlimentazione.DataTextField = "Alimentazione";
                ddlAlimentazione.DataValueField = "Id";
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            if (!IsFormValido())
            {
                //Visualizzo un messaggio di errore
               // InfoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Danger, "Il form non è valido, nessun record inserito");
                return;
            }
            //var nome = txtNome.Text;
            VeicoloManager veicoloManager = new VeicoloManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;Persist Security Info=True;User ID=utente;Password=Safo2022!");
            var veicoloModel = new VeicoloModel();
            
            veicoloModel.Modello= txtModello.Text;
            veicoloModel.Targa = txtTarga.Text;
            veicoloModel.Note = txtNote.Text;
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataImmatricolazione.Text, out dateTimeResult);
            if (okParse)
            {
               veicoloModel.DataImmatricolazione = dateTimeResult;
            }
            veicoloModel.IdMarca = int.Parse(ddlMarca.SelectedValue);
            veicoloModel.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);

            bool isVeicoloInserita = veicoloManager.InsertVeicolo(veicoloModel);


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
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                return false;
            }

            return true;
        }
        protected void dataImmatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            // Clear the current text.
            txtDataImmatricolazione.Text = "";

            // Iterate through the SelectedDates collection and display the
            // dates selected in the Calendar control.
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {

                txtDataImmatricolazione.Text += day.Date.ToShortDateString();

            }
            

        }
        protected void btnData_Click(object sender, EventArgs e)
        {
            if (dataImmatricolazione.Visible==false)
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