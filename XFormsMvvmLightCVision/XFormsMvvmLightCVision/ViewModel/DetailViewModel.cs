using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFormsMvvmLightCVision.Model;
using XFormsMvvmLightCVision.Service;

namespace XFormsMvvmLightCVision.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ICognitiveClient _cognitiveClient;

        ImageSource _myImageSource;
        public ImageSource MyImageSource
        {
            get
            {
                //if (_myImageSource == null)
                //{
                //    switch (Device.RuntimePlatform)
                //    {
                //        case Device.iOS:
                //            ImageSource.FromFile("Images/picture.png");
                //            break;
                //        case Device.Android:
                //            ImageSource.FromFile("picture.png");
                //            break;
                //        case Device.UWP:
                //            ImageSource.FromFile("Images/wpicture.png");
                //            break;
                //    }
                //}
                return _myImageSource;
            }

            set
            {
                Set(ref _myImageSource, value);
            }
        }

        string _imageDescription;
        public string ImageDescription
        {
            get
            {
                return _imageDescription;
            }

            set
            {
                Set(ref _imageDescription, value);
            }
        }

        bool _progressVisible;
        public bool ProgressVisible
        {
            get
            {
                return _progressVisible;
            }

            set
            {
                Set(ref _progressVisible, value);
            }
        }

        Person _person;
        public Person Person
        {
            get
            {
                return _person;
            }

            set
            {
                Set(ref _person, value);
            }
        }

        public ICommand AddNewImage { get; private set; }


        public DetailViewModel(INavigationService navigationService, ICognitiveClient cognitiveClient)
        {
            _navigationService = navigationService;
            _cognitiveClient = cognitiveClient;
            Messenger.Default.Register<Person>(this, person =>
            {
                Person = person;
            });
            AddNewImage = new Command(async () => await OnAddNewImage());
        }


        private async Task OnAddNewImage()
        {
            ImageDescription = string.Empty;
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var image = await CrossMedia.Current.PickPhotoAsync();
                if (image != null)
                {
                    var stream = image.GetStream();
                    MyImageSource = ImageSource.FromStream(() =>
                    {
                        return stream;
                    });
                    try
                    {
                        ProgressVisible = true;
                        var result = await _cognitiveClient.GetImageDescription(image.GetStream());
                        image.Dispose();

                        Person person = new Person()
                        {
                            Name = string.Empty,
                            Surname = string.Empty,
                            //Information = result.Description.Tags
                        };

                        result.Description.Captions.ToList().ForEach(f => { person.Information.Add(f.Text); });

                        foreach (string tag in person.Information)
                        {
                            ImageDescription = ImageDescription + "\n" + tag;
                        }
                    }
                    //Microsoft.ProjectOxford.Vision.ClientException
                    catch (Exception ex)
                    {

                        ImageDescription = ex.Message;
                    }
                    ProgressVisible = false;
                }
            }
        }
    }
}
