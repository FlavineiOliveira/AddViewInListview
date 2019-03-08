using AppListview.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppListview.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Lista> _lista;

        public ObservableCollection<Lista> Lista
        {
            get { return _lista; }
            set { _lista = value; }
        }

        public ICommand RemoverBoxCommand { get;set;}

        public MainViewModel()
        {
            Lista = new ObservableCollection<Lista>();

            var listaSubItems = new List<string>
            {
                "Sub Item 1",
                "Sub Item 2",
                "Sub Item 3"
            };

            Lista.Add(new Lista() { Nome = "Item 1", AddButtonCommand = new Command(AdicionarView) });
            Lista.Add(new Lista() { Nome = "Item 2", AddButtonCommand = new Command(AdicionarView) });
            Lista.Add(new Lista() { Nome = "Item 3", AddButtonCommand = new Command(AdicionarView) });

            RemoverBoxCommand = new Command((object pLayout) => RemoverBox(pLayout));
        }

        private void AdicionarView(object entrada)
        {
            var adicionarView = (StackLayout)entrada;

            var box = new BoxView()
            {
                BackgroundColor = Color.Blue,
                StyleId = "box",
            };

            var gesture = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1,
                Command = RemoverBoxCommand,
                CommandParameter = entrada
            };
            box.GestureRecognizers.Add(gesture);            

            adicionarView.Children.Add(box);

        }

        private void RemoverBox(object pLayout)
        {
            var layout = (StackLayout)pLayout;

            var layoutViews = layout.FindByName<StackLayout>("addViews");

            //Removendo box da posição definida 0
            layoutViews.Children.RemoveAt(0);
        }


    }
}
