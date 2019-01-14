using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFormsMvvmLightCVision.Config;
using XFormsMvvmLightCVision.Model;

namespace XFormsMvvmLightCVision.Service
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand NavigateCommand { get; private set; }


        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new Command(() => Navigate());
        }

        private void Navigate()
        {
            var person = new Person() { Name = "Marco" };
            Messenger.Default.Send(person);
            _navigationService.NavigateTo(AppPages.DetailPage, person);
        }

    }
}
