using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoloApplication.Business.Models
{
    public class ClienteModel
    {
        public string NomeCliente { get; set; }
        public int IdVeicolo { get; set; }
        public string CodiceFiscale { get; set; }
        public DateTime? DataNascita { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string NumeroPatente { get; set; }
        public string Nazione { get; set; }
        public string Provincia { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
    }
}
