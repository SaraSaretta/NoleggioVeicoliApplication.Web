using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static NoleggioVeicoli.WebApplication.Controls.VeicoloControl;

namespace NoleggioVeicoli.WebApplication
{
    public partial class DettaglioVeicolo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            int? idVeicolo = null;
            idVeicolo = Convert.ToInt32(Session["id"]);
            veicoloControl.SetVeicolo(idVeicolo);
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {

        }

        protected void btnAvanti_Click(object sender, EventArgs e)
        {

        }

        protected void veicoloControl_VeicoloModelUpdated1(object sender, EventArgsPersonalizzato e)
        {
            if (e.Messaggio != null)
            {
                infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Success, e.Messaggio);
            }

        }
    }
}