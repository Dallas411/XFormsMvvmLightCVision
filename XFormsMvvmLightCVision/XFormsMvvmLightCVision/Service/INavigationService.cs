
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFormsMvvmLightCVision.Config;

namespace XFormsMvvmLightCVision.Service
{
    public interface INavigationService
    {
        void Configure(AppPages pageKey, Type pageType);
        void Initialize(NavigationPage page);
        void GoBack();
        void NavigateTo(AppPages pageKey);
        void NavigateTo(AppPages pageKey, object parameter);
    }
}
