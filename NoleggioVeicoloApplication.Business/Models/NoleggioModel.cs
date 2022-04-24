using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoloApplication.Business.Models
{
    public class NoleggioModel
    {
        public int Id { get; set; }
        public int IdVeicolo { get; set; }
        public string NomeCliente { get; set; }
    }
}
