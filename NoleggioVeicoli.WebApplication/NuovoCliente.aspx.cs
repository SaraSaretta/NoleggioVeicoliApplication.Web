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
    public partial class NuovaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            var id = (int)Session["id"];

            var noleggioManager = new NoleggioManager(Properties.Settings.Default.Safo2022);
            var noleggioModel = new NoleggioModel();
            noleggioModel = noleggioManager.GetNoleggio(id);
            txtCliente.Text = noleggioModel.NomeCliente;

            var clienteModel = new ClienteModel();
            clienteModel.NomeCliente = noleggioModel.NomeCliente;
            clienteModel.CodiceFiscale = txtCodiceFiscale.Text;
            clienteModel.Email = txtEmail.Text;
            clienteModel.Telefono = txtTelefono.Text;
            clienteModel.NumeroPatente = txtNumeroPatente.Text;
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataNascita.Text, out dateTimeResult);
            if (okParse)
            {
                clienteModel.DataNascita = dateTimeResult;
            }
            clienteModel.Nazione = txtNazione.Text;
            clienteModel.Provincia = txtProvincia.Text;
            clienteModel.Citta = txtCitta.Text;
            clienteModel.Indirizzo = txtIndirizzo.Text;

            bool isDatiClienteUpdate = noleggioManager.UpdateDatiCliente(clienteModel);
            infoControl.SetMessage(WebApplication.Controls.InfoControl.TipoMessaggio.Success, $"I dati di {clienteModel.NomeCliente} sono stati salvati corettamente!!");

        }
        protected void btnData_Click(object sender, EventArgs e)
        {
            if (dataNascita.Visible == false)
            {
                dataNascita.Visible = true;
            }
            var clienteModel = new ClienteModel();
            DateTime dateTimeResult;
            var okParse = DateTime.TryParse(txtDataNascita.Text, out dateTimeResult);
            if (okParse)
            {
                clienteModel.DataNascita = dateTimeResult;
            }
        }
        protected void dataNascita_SelectionChanged(object sender, EventArgs e)
        {
            txtDataNascita.Text = "";
            foreach (DateTime day in dataNascita.SelectedDates)
            {
                txtDataNascita.Text += day.Date.ToShortDateString();
            }
        }
    }
}