using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFormsMvvmLightCVision.Model;

namespace XFormsMvvmLightCVision.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        public DetailPage(Person person)
        {
			InitializeComponent ();
            BindingContext = App.Locator.DetailViewModel;
            App.Locator.DetailViewModel.Person = person;
        }
	}
}