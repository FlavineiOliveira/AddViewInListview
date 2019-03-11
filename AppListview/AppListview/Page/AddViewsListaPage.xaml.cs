using AppListview.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListview.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddViewsListaPage : ContentPage
	{
		public AddViewsListaPage ()
		{
			InitializeComponent();

            BindingContext = new AddViewsListaViewModel();
        }
	}
}