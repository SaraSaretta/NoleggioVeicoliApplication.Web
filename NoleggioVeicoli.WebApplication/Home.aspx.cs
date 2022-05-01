using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioVeicoli.WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            Response.Redirect("InserisciVeicolo.aspx");
        }
        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            Response.Redirect("RicercaVeicolo.aspx");
        }
    }
}