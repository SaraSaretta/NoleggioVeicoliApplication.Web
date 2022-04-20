using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliApplication.Business.Models
{
    public class RicercaVeicoloModel
    {
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public string StatoNoleggio { get; set; }


    }
}
