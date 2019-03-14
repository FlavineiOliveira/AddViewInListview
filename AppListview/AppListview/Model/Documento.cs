using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppListview.Model
{
    public class Documento
    {
        private ICommand _definirLayoutListaCommand;

        public ICommand DefinirLayoutListaCommand
        {
            get { return _definirLayoutListaCommand; }
            set { _definirLayoutListaCommand = value; }
        }

        private ICommand _addViewCommand;

        public ICommand AddViewCommand
        {
            get { return _addViewCommand; }
            set { _addViewCommand = value; }
        }

        private ICommand _removerViewCommand;

        public ICommand RemoverViewCommand
        {
            get { return _removerViewCommand; }
            set { _removerViewCommand = value; }
        }

        public string Nome { get; set; }

        public List<string> SubItem { get; set; }

        public Documento()
        {
            SubItem = new List<string>();
        }
    }
}
