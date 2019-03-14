using AppListview.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListview.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddViewPage : ContentPage
	{
		public AddViewPage ()
		{
			InitializeComponent ();

            BindingContext = new AddViewViewModel();
		}
	}
}