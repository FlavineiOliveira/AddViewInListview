using AppListview.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppListview.ViewModel
{
    public class FindViewAndAddViewModel : BaseViewModel
    {
        private StackLayout _layoutLista;

        public List<Documento> Documentos { get; set; }

        private ICommand _definirLayoutListaCommand;

        public ICommand DefinirLayoutListaCommand
        {
            get { return _definirLayoutListaCommand; }
            set { _definirLayoutListaCommand = value; }
        }

        private ICommand _adicionarViewCommand;

        public ICommand AdicionarViewCommand
        {
            get { return _adicionarViewCommand; }
            set { _adicionarViewCommand = value; }
        }


        public FindViewAndAddViewModel()
        {
            _layoutLista = new StackLayout();

            //OBS: Adicionar Commands no objeto da Lista que estará no ItemSource
            Documentos = new List<Documento>()
            {
                new Documento{ Nome = "RG", AddViewCommand = new Command((object entrada) => AdicionarView(entrada)), DefinirLayoutListaCommand = new Command((object entrada) => DefinirLayoutLista(entrada)) },
                new Documento{ Nome = "CPF", AddViewCommand = new Command((object entrada) => AdicionarView(entrada)), DefinirLayoutListaCommand = new Command((object entrada) => DefinirLayoutLista(entrada)) },
                new Documento{ Nome = "Habilitacao", AddViewCommand = new Command((object entrada) => AdicionarView(entrada)), DefinirLayoutListaCommand = new Command((object entrada) => DefinirLayoutLista(entrada)) },
            };
        }

        public void DefinirLayoutLista(object entrada)
        {
            _layoutLista = (StackLayout)entrada;
        }

        public void AdicionarView(object entrada)
        {
            var contador = (Documento)entrada;

            var frame = new Frame()
            {
                Padding = 10,
                BackgroundColor = Color.Brown
            };

            var label = new Label()
            {
                Text = string.Format("VIEW {0}", _layoutLista.Children.Count),
                TextColor = Color.White
            };

            //Gesture passando o layout como parâmetro
            var gestureLayout = new TapGestureRecognizer()
            {
                Command = new Command((object p) => DefinirLayoutLista(p)),
                CommandParameter = _layoutLista
            };

            //Gesture removendo a view da tela
            var gestureFrame = new TapGestureRecognizer()
            {
               Command = new Command((object p) => RemoverView(p)),
               CommandParameter = frame
            };

            //Gesture removendo o item da lista
            var gestureInfos = new TapGestureRecognizer()
            {
                Command = new Command((object p) => RemoverItemLista(p)),
                CommandParameter = entrada
            };

            frame.GestureRecognizers.Add(gestureLayout);
            frame.GestureRecognizers.Add(gestureInfos);
            frame.GestureRecognizers.Add(gestureFrame);
            frame.Content = label;

            _layoutLista.Children.Add(frame);
        }

        public void RemoverView(object entrada)
        {
            _layoutLista.Children.Remove((Frame)entrada);
        }

        public void RemoverItemLista(object entrada)
        {
           //Remover item da lista aqui
        }
    }
}
