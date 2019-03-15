using AppListview.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListview.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddDataTemplatePage : ContentPage
	{
        AddDataTemplateViewModel addDataTemplateViewModel;

        public AddDataTemplatePage ()
		{
			InitializeComponent ();

            addDataTemplateViewModel = new AddDataTemplateViewModel();
            BindingContext = addDataTemplateViewModel;

            ConstruirTemplate();
        }

        public void ConstruirTemplate()
        {
            addDataTemplateViewModel.Lista = ListViewDocumentos;
            addDataTemplateViewModel.ConstruirTemplate();
        }
	}
}