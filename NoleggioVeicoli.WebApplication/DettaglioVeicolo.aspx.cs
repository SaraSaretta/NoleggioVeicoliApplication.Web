using NoleggioVeicoli.WebApplication.Controls;
using NoleggioVeicoli.WebApplication.Properties;
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
    public partial class DettaglioVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            int idVeicolo = Convert.ToInt32(Session["id"]);
            veicoloControl.SetVeicolo(idVeicolo);
        }
        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            var listaVeicolo = (List<VeicoloModel>)Session["listaVeicoloView"];
            var idVeicoloCorrente = Convert.ToInt32(Session["id"]);
            var indexCorrente = 0;
            foreach (var item in listaVeicolo)
            {
                if (idVeicoloCorrente == item.Id)
                {
                    indexCorrente = listaVeicolo.IndexOf(item);
                    break;
                }
            }
            var indexVeicoloPrecedente = indexCorrente - 1;
            var veicoloPrecedente = listaVeicolo[indexVeicoloPrecedente];
            btnIndietro.Enabled = true;
            if (indexVeicoloPrecedente == 0)
            {
                btnIndietro.Enabled = false;
            }
            else
            {
                btnIndietro.Enabled = true;
            }
            //aggiorna dati pagina
            veicoloControl.SetVeicolo(veicoloPrecedente.Id);
        }
        protected void btnAvant_Click(object sender, EventArgs e)
        {
            var listaVeicolo = (List<VeicoloModel>)Session["listaVeicoloView"];
            var idVeicoloCorrente = Convert.ToInt32(Session["id"]);
            var indexCorrente = 0;
            foreach (var item in listaVeicolo)
            {
                if (idVeicoloCorrente == item.Id)
                {
                    indexCorrente = listaVeicolo.IndexOf(item);
                    break;
                }
            }
            var indexVeicoloSuccessivo = indexCorrente + 1;
            var veicoloSuccessivo = listaVeicolo[indexVeicoloSuccessivo];
            btnAvanti.Enabled = true;
            if (indexVeicoloSuccessivo == listaVeicolo.Count - 1)
            {
                btnAvanti.Enabled = false;
            }
            else
            {
                btnAvanti.Enabled = true;
            }
            //aggiorna dati pagina
            veicoloControl.SetVeicolo(veicoloSuccessivo.Id);
        }
        protected void veicoloControl_VeicoloModelUpdated(object sender, EventArgsPersonalizzato e)
        {
            if (e.Messaggio.Equals("Il veicolo è stato eliminato correttamente!"))
            {
                infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Success, e.Messaggio);
            }
            if (e.Messaggio.Equals("ATTENZIONE! Il veicolo non può essere eliminato,perhcé è stato noleggiato!"))
            {
                infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Warning, e.Messaggio);
            }
            if (e.Messaggio.Equals("Il veicolo è stato modificato con successo!"))
            {
                infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Success, e.Messaggio);
            }
        }

    }
}