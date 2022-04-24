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
            txtMarca.Text = veicoloModel.Marca;
            txtModello.Text = veicoloModel.Modello;
            txtTarga.Text = veicoloModel.Targa;
            txtAlimentazione.Text = veicoloModel.TipoAlimentazione;
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
        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            var id = (int)Session["id"];
            var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
            var modificaVeicoloModel = veicoloManager.GetVeicolo(id);
            modificaVeicoloModel.Marca = txtMarca.Text;
            modificaVeicoloModel.Modello = txtModello.Text;
            modificaVeicoloModel.Targa = txtTarga.Text;
            modificaVeicoloModel.TipoAlimentazione = txtAlimentazione.Text;
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
    }
}