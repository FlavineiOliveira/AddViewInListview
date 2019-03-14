using AppListview.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListview.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindViewAndAddPage : ContentPage
    {
        public FindViewAndAddPage()
        {
            InitializeComponent();

            BindingContext = new FindViewAndAddViewModel();
        }
    }
}