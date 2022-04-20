using NoleggioVeicoli.WebApplication.Properties;
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
    public partial class Veicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var veicoloManager = new VeicoloManager(Settings.Default.Safo2022);
            List<VeicoloModel> veicoloList = veicoloManager.GetVeicoloList();
            gvVeicolo.DataSource = veicoloList;
            gvVeicolo.DataBind();

            infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Info, $"Sono state individuate :{veicoloList.Count } veicoli");

        }
    }
}