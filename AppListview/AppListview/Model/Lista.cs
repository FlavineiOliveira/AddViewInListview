using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppListview.Model
{
    public class Lista
    {
        public string Nome { get; set; }
        public List<string> SubItems { get; set; }
        public ICommand AddButtonCommand { get; set; }
        public List<BoxView> Box { get; set; }
    }
}
