using NoleggioVeicoloApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoloApplication.Business.Managers
{
    public class SingletonManager
    {
        private const int MINUTI_AGGIORNAMENTO_LISTA_MARCA = 20;
        private static SingletonManager instance = null;
        private List<MarcaModel> listMarche = null;
        private DateTime LastAggiornamentoListaMarche = DateTime.MinValue;
        public static SingletonManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonManager();
                return instance;
            }
        }
        public List<MarcaModel> ListMarche
        {
            get
            {
                VeicoloManager veicolo = new VeicoloManager(Properties.Settings.Default.ConnectionString);
                if (DateTime.Now > LastAggiornamentoListaMarche.AddMinutes(MINUTI_AGGIORNAMENTO_LISTA_MARCA))
                    veicolo.GetMarcaList();
                return listMarche;
            }
        }
        private SingletonManager()
        {
            VeicoloManager veicolo = new VeicoloManager(Properties.Settings.Default.ConnectionString);
            listMarche = veicolo.GetMarcaList();
        }
    }
}

