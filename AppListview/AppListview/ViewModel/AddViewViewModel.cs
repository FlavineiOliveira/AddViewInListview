using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppListview.ViewModel
{
    public class AddViewViewModel : BaseViewModel
    {
        private ICommand _addViewCommand;
        public ICommand AdicionarViewCommand
        {
            get { return _addViewCommand; }
            set { _addViewCommand = value; }
        }

        private ICommand _localizarBoxCommand;
        public ICommand LocalizarBoxCommand
        {
            get { return _localizarBoxCommand; }
            set { _localizarBoxCommand = value; }
        }

        private ICommand _variosParamCommand;
        public ICommand VariosParamCommand
        {
            get { return _variosParamCommand; }
            set { _variosParamCommand = value; }
        }

        public AddViewViewModel()
        {
            AdicionarViewCommand = new Command((object entrada) => AdicionarView(entrada));
            LocalizarBoxCommand = new Command((object entrada) => LocalizarViewPorStyleId(entrada));
        }

        public void AdicionarView(object entrada)
        {
            var stack = (StackLayout)entrada;

            var box = new BoxView()
            {
                BackgroundColor = Color.Red,
            };

            stack.Children.Add(box);
        }

        public void LocalizarViewPorStyleId(object entrada)
        {
            var stack = (StackLayout)entrada;
        }
    }
}
