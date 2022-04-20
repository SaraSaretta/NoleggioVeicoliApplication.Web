using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoloApplication.Business.Models
{
    public class VeicoloModel
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public int IdAlimentazione { get; set; }
        public string TipoAlimentazioneDesc { get; set; }
        public string Note { get; set; }
        public bool? StatoNoleggio { get; set; }
    }
}
