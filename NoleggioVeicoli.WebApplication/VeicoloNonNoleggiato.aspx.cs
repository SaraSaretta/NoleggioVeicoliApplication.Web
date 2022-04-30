using NoleggioVeicoli.WebApplication.Properties;
using NoleggioVeicoloApplication.Business.Managers;
using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioVeicoli.WebApplication
{
    public partial class VeicoloNonNoleggiato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            int idVeicolo = Convert.ToInt32(Session["id"]);
            SetVeicoloNonNoleggiato(idVeicolo);
        }
        public void SetVeicoloNonNoleggiato(int? idVeicolo)
        {
            Session["id"] = idVeicolo;
            var noleggioManager = new NoleggioManager(Properties.Settings.Default.Safo2022);
            var noleggioModel = new NoleggioModel();
            noleggioModel = noleggioManager.GetNoleggio(idVeicolo);
            txtMarca.Text = noleggioModel.Marca;
            txtModello.Text = noleggioModel.Modello;
            txtTarga.Text = noleggioModel.Targa;
            txtCliente.Text = noleggioModel.NomeCliente;
        }
        protected void btnNoleggiaVeicolo_Click(object sender, EventArgs e)
        {
            var idVeicolo = (int)Session["id"];
            var noleggioManager = new NoleggioManager(Settings.Default.Safo2022);
            var noleggioModel = new NoleggioModel();
            noleggioModel = noleggioManager.GetNoleggio(idVeicolo);
            noleggioModel.NomeCliente = txtCliente.Text;

            bool isClienteInserito = noleggioManager.InsertNoleggio(noleggioModel);
            infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Success, "Il veicolo è stato noleggiato con successo!");
            bool isDatiNoleggioModificati = noleggioManager.UpdateNoleggio(noleggioModel);
        }
        protected void btnRegistraCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuovoCliente.aspx");
        }
    }
}