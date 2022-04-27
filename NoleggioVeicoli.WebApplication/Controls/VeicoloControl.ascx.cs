using NoleggioVeicoli.WebApplication.Properties;
using NoleggioVeicoloApplication.Business.Managers;
using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioVeicoli.WebApplication.Controls
{
    public partial class VeicoloControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            VeicoloManager veicoloManager = new VeicoloManager(Properties.Settings.Default.Safo2022);

            List<TipoAlimentazioneModel> tipoAlimentazioneList = veicoloManager.GetTipoAlimentazione();

            ddlAlimentazione.DataSource = tipoAlimentazioneList;
            ddlAlimentazione.DataValueField = "Id";
            ddlAlimentazione.DataTextField = "Alimentazione";
            ddlAlimentazione.DataBind();
            ddlAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

            List<MarcaModel> marcaList = veicoloManager.GetMarcaList();

            ddlMarca.DataSource = marcaList;
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataTextField = "Marca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
           
        }

        public event EventHandler<EventArgsPersonalizzato> VeicoloModelUpdated;
        public class EventArgsPersonalizzato : EventArgs
        {
            public string Messaggio { get; set; }
            public int? IdVeicoloModificato { get; set; }

        }
        public void SetVeicolo(int? id)
        {
            Session["id"] = id;
            var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
            var veicoloModel = veicoloManager.GetVeicolo(id);
            ddlMarca.SelectedValue = veicoloModel.IdMarca.ToString();
            txtModello.Text = veicoloModel.Modello;
            txtTarga.Text = veicoloModel.Targa;
            ddlAlimentazione.SelectedValue = veicoloModel.IdTipoAlimentazione.ToString();
            txtStatoNoleggio.Text = veicoloModel.StatoNoleggio;
            txtDataImmatricolazione.Text = (veicoloModel.DataImmatricolazione).ToString();
            var formatoData = "dd/MM/yyyy";
            string data = "";
            if (veicoloModel.DataImmatricolazione.HasValue)
            {
                data = veicoloModel.DataImmatricolazione.Value.ToString(formatoData);
            }
            txtDataImmatricolazione.Text = data;
            txtNote.Text = veicoloModel.Note;
            if (txtStatoNoleggio.Text.Equals("Si"))
            {
                
                var noleggioManager = new NoleggioManager(Properties.Settings.Default.Safo2022);
                var clienteModel = noleggioManager.GetCliente(id);
                txtCliente.Text = clienteModel.NomeCliente;
            }
            else
            {
                NomeCliente.Visible = false;
               
            }


        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            var id = (int)Session["id"];
            var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
            var modificaVeicoloModel = veicoloManager.GetVeicolo(id);
            if (!int.TryParse(ddlMarca.SelectedValue, out int idMarca) || idMarca <= 0)
            {
                return;
            }
            modificaVeicoloModel.IdMarca = idMarca;
            modificaVeicoloModel.Modello = txtModello.Text;
            modificaVeicoloModel.Targa = txtTarga.Text;
            if (!int.TryParse(ddlAlimentazione.SelectedValue, out int idTipoAlimentazione) || idTipoAlimentazione <= 0)
            {
                return;
            }
            modificaVeicoloModel.IdTipoAlimentazione = idTipoAlimentazione;
            modificaVeicoloModel.StatoNoleggio = txtStatoNoleggio.Text;
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataImmatricolazione.Text, out dateTimeResult);
            if (okParse)
            {
                modificaVeicoloModel.DataImmatricolazione = dateTimeResult;
            }
            modificaVeicoloModel.Note = txtNote.Text;

            var updateVeicoloModel = veicoloManager.UpdateVeicolo(modificaVeicoloModel);
            var eventArgsPersonalizzato = new EventArgsPersonalizzato();
            eventArgsPersonalizzato.Messaggio = "Il veicolo è stato modificato con successo!";
            VeicoloModelUpdated(this, eventArgsPersonalizzato);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStatoNoleggio.Text == "No")
            {
                var id = (int)Session["id"];
                var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
                var modificaVeicoloModel = veicoloManager.GetVeicolo(id);

                var updateVeicoloMode = veicoloManager.DeleteVeicolo(modificaVeicoloModel);
                var eventArgsPersonalizzato = new EventArgsPersonalizzato();
                eventArgsPersonalizzato.Messaggio = "Il veicolo è stato eliminato";
                VeicoloModelUpdated(this, eventArgsPersonalizzato);

            }
            else
            {
                var eventArgsPersonalizzato = new EventArgsPersonalizzato();
                eventArgsPersonalizzato.Messaggio = "Il veicolo non può essere eliminato";
                VeicoloModelUpdated(this, eventArgsPersonalizzato);


            }
        }

        protected void btnGestisciNoleggio_Click(object sender, EventArgs e)
        {
            if (txtStatoNoleggio.Text=="Si")
            {
                Response.Redirect("VeicoloNoleggiato.aspx");

            }
            else
            {
                Response.Redirect("VeicoloNonNoleggiato.aspx");

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

        protected void dataImmatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            txtDataImmatricolazione.Text = "";
            foreach (DateTime day in dataImmatricolazione.SelectedDates)
            {
                txtDataImmatricolazione.Text += day.Date.ToShortDateString();
            }
        }
    }
}
