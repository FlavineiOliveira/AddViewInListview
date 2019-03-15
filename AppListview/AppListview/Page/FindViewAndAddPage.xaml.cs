using AppListview.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListview.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindViewAndAddPage : ContentPage
    {
        FindViewAndAddViewModel findViewAndAddViewModel;

        public FindViewAndAddPage()
        {
            InitializeComponent();

            findViewAndAddViewModel = new FindViewAndAddViewModel();
            BindingContext = findViewAndAddViewModel;

            ConstruirTemplate();
        }

        public void ConstruirTemplate()
        {
            findViewAndAddViewModel.Lista = this.FindByName<ListView>("ListaDocs");
            findViewAndAddViewModel.ConstruirTemplate();
        }
    }
}