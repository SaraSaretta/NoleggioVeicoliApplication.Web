using NoleggioVeicoli.WebApplication.Properties;
using NoleggioVeicoloApplication.Business.Managers;
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


            VeicoloManager veicoloManager = new VeicoloManager(Settings.Default.Safo2022);

            if (IsPostBack)
            {
                return;
            }
            int idVeicolo = Convert.ToInt32(Session["id"]);

            //var getVeicoloModel = veicoloManager.GetVeicolo(idVeicolo);
            //txtMarca.Text = getVeicoloModel.Marca;
            //txtModello.Text = getVeicoloModel.Modello;
            //txtTarga.Text=getVeicoloModel.Targa ;

        }
        protected void btnNoleggiaVeicolo_Click(object sender, EventArgs e)
        {



        }
    }
}