using AppListview.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListview.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFullPage : ContentPage
    {
        public ListaFullPage()
        {
            InitializeComponent();

            BindingContext = new ListaFullViewModel();
        }
    }
}