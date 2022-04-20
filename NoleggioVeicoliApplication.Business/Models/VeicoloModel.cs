using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliApplication.Business.Models
{
    public class VeicoloModel
    {
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public string Alimentazione { get; set; }
        public string Note { get; set; }

    }
}
