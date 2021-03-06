﻿using AppListview.Model;
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
        public ListView Lista;

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

        public void ConstruirTemplate()
        {
            if (Documentos?.Count > 0)
            {

                var dataTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                    var label = new Label();
                    
                    var frame = new Frame();

                    var boxView = new BoxView()
                    {
                        BackgroundColor = Color.Red,
                        HeightRequest = 100,
                        WidthRequest = 100
                    };

                    var scrollView = new ScrollView()
                    {
                        Orientation = ScrollOrientation.Horizontal
                    };

                    var stack = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal
                    };

                    foreach (var item in Documentos)
                    {
                        label.Text = item.Nome;

                        stack.Children.Add(AdicionarView(item));
                    }

                    var gestureDefinirLayout = new TapGestureRecognizer()
                    {
                        Command = DefinirLayoutListaCommand,
                        CommandParameter = grid
                    };

                    var gestureAddView = new TapGestureRecognizer()
                    {
                        Command = AdicionarViewCommand,
                        CommandParameter = Documentos
                    };

                    grid.Children.Add(label, 0, 0);
                    Grid.SetColumnSpan(label, 3);

                    grid.Children.Add(frame, 0, 1);
                    grid.Children.Add(boxView, 1, 1);
                    grid.Children.Add(scrollView, 2, 1);

                    return new ViewCell { View = grid };
                });

                Lista.ItemTemplate = dataTemplate;
            };
        }

        public void DefinirLayoutLista(object entrada)
        {
            _layoutLista = (StackLayout)entrada;
        }

        public Frame AdicionarView(object entrada)
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

            return frame;
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
