using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoloApplication.Business.Models
{
    public class RicercaVeicoloModel
    {
        public int IdMarca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public int? IdTipoAlimentazione { get; set; }
        public DateTime? DataImmatricolazioneInizio { get; set; }
        public DateTime? DataImmatricolazioneFine { get; set; }
        public string StatoNoleggio { get; set; }
    }
}
