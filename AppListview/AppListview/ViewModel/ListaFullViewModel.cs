using System.Collections.Generic;

namespace AppListview.ViewModel
{
    public class ListaFullViewModel : BaseViewModel
    {
        private List<string> _nomes;

        public List<string> Nomes
        {
            get { return _nomes; }
            set
            {
                _nomes = value;
                OnPropertyChanged();
            }
        }

        public ListaFullViewModel()
        {
            Nomes = new List<string>()
            {
                "Ajuricaba Borges",
                "Elia Guimaraens",
                "Felisbela Castel-Branco",
                "Fiona Alcântara",
                "Floripes Rebelo",
                "Geraldo Varanda",
                "Jéssica Alcantara",
                "Luana Arouca",
                "Nivaldo Pino",
                "Otávio Guimaraes",
                "Ramão Cachão",
                "Renata Botelho",
                "Rodrigo Aguiar",
                "Rosalina Portella",
                "Rubim Ferraço",
                "Rute Morera",
                "Socorro Barrios",
                "Teresa Torcato",
                "Vitória Ríos",
                "Viviana Saraiva"
            };
        }

    }
}
